using Microsoft.AspNetCore.Identity;

namespace Lexicon_LMS.Shared.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int? CourseId { get; set; } = null!;

    }
}
