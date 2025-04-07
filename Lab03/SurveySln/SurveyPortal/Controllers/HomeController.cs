using Microsoft.AspNetCore.Mvc;
using SurveyPortal.Models;
using SurveyPortal.Models.ViewModels;

namespace SurveyPortal.Controllers
{
    public class HomeController : Controller
    {
        private ISurveyRepository _repository;
        public const int PageSize = 4;

        public HomeController(ISurveyRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index(string? category, int page = 1)
        {
            var query = _repository.Surveys;

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(s => s.Category == category);
            }

            var model = new SurveyListViewModel
            {
                Surveys = query
                .OrderBy(s => s.CreatedAt)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = query.Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }
        public IActionResult Details(long id)
        {
            var survey = _repository.Surveys.FirstOrDefault(s => s.SurveyID == id);

            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }
        [HttpPost]
        public IActionResult SaveSurveyAnswer(long SurveyID, string Answer)
        {
            var survey = _repository.Surveys.FirstOrDefault(s => s.SurveyID == SurveyID);

            if (survey == null || string.IsNullOrWhiteSpace(Answer))
            {
                return NotFound();
            }

            _repository.AddAnswer(new SurveyAnswers
            {
                SurveyID = SurveyID,
                Answer = Answer,
                AnsweredAt = DateTime.UtcNow
            });

            TempData["Message"] = "Thank you for your answer!";
            return RedirectToAction("Details", new { id = SurveyID });
        }

        public IActionResult SaveDraftAnswer(long surveyId, [FromBody] DraftDto dto)
        {
            var key = $"draft_{surveyId}";
            HttpContext.Session.SetString(key, dto.Answer ?? "");

            return Ok();
        }

        public class DraftDto
        {
            public string Answer { get; set; }
        }
    }

}
