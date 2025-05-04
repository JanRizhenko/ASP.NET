using Microsoft.AspNetCore.Identity;

namespace SurveyPortal.Models.Identity.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
