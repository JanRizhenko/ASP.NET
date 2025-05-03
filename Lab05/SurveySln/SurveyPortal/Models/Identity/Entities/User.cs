using Microsoft.AspNetCore.Identity;

namespace SurveyPortal.Models.Identity.Entities
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
