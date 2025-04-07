namespace SurveyPortal.Models
{
    public interface ISurveyRepository
    {
        IQueryable<Survey> Surveys { get; }
        void AddAnswer(SurveyAnswers answer);

    }
}
