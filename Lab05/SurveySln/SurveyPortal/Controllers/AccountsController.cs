using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurveyPortal.Models.Identity.Entities;
using AutoMapper;
using SurveyPortal.Models.Identity.DTO;

namespace SurveyPortal.Controllers
{
    public class AccountsController : Controller
    {
        private readonly SignInManager<User> _signInManager; // Fixed variable name
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AccountsController(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper)
        {
            _signInManager = signInManager; // Fixed assignment
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginDto userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email or password is incorrect.");
                    return View(userModel);
                }
                    
            }
            return View(userModel);
        }

        public IActionResult VerifyEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(EmailVerificationDto userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userModel.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Email", "No account found with this email address.");
                    return View(userModel);
                }

                else
                    return RedirectToAction("ChangePassword", "Accounts", new {username = userModel.Email});
            }

            return View(userModel);
        }



        public IActionResult ChangePassword(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("VerifyEmail", "Accounts");
            }
            return View(new ChangePasswordDto { Email = userName });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(userModel.Email);
                if (user != null)
                {
                    var result = await _userManager.RemovePasswordAsync(user);
                    if (result.Succeeded)
                    {
                        result = await _userManager.AddPasswordAsync(user, userModel.NewPassword);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Login", "Accounts");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Failed to set new password.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to remove old password.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email not found!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid input data.");
            }

            return View(userModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserForRegistrationDto userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            var existingUser = await _userManager.FindByEmailAsync(userModel.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Email is already taken.");
                return View(userModel);
            }
            var user = _mapper.Map<User>(userModel);

            user.UserName = userModel.Email;

            var result = await _userManager.CreateAsync(user, userModel.Password);

            if (!result.Succeeded)
            {
                return View(userModel);
            }

            await _userManager.AddToRoleAsync(user, "Visitor");

            return RedirectToAction("Login", "Accounts");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
