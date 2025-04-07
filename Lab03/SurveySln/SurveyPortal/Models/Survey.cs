using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyPortal.Models
{
    public class Survey
    {
        [Key]
        public long? SurveyID { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddTicks(-(DateTime.UtcNow.Ticks % TimeSpan.TicksPerSecond));
        public string Category { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<SurveyAnswers> SurveyAnswers { get; set; } = new List<SurveyAnswers>();
    }
}