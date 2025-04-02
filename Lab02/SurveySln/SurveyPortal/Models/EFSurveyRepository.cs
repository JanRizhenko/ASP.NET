namespace SurveyPortal.Models
{
    public class EFSurveyRepository : ISurveyRepository
    {
        private readonly SurveyDbContext _context;
        public EFSurveyRepository(SurveyDbContext context)
        {
            _context = context;
        }
        public IQueryable<Survey> Surveys => _context.Surveys;
    }
}
