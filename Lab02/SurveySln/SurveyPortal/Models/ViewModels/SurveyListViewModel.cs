
namespace SurveyPortal.Models.ViewModels
{
    public class SurveyListViewModel
    {
        public IEnumerable<Survey> Surveys { get; set; } = new List<Survey>();
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();
    }
}
