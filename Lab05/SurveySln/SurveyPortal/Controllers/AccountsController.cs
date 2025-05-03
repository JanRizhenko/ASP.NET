using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurveyPortal.Models.Identity.Entities;
using AutoMapper;
using SurveyPortal.Models.Identity.DTO;

namespace SurveyPortal.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        
        public AccountsController(UserManager<User> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            ViewData["ShowNavigationMenu"] = false;
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewData["ShowNavigationMenu"] = false;
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

            return RedirectToAction("Index", "Home");
        }

    }
}
