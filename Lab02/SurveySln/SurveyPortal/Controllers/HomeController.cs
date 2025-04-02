using Microsoft.AspNetCore.Mvc;
using SurveyPortal.Models;
using SurveyPortal.Models.ViewModels;

namespace SurveyPortal.Controllers
{
    public class HomeController : Controller
    {
        private ISurveyRepository _repository;
        public const int PageSize = 6;

        public HomeController(ISurveyRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index(int page = 1)
        {
            var query = _repository.Surveys;
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
                }
            };

            return View(model);
        }

    }

}
