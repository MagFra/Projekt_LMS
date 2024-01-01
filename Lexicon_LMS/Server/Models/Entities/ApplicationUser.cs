using Microsoft.AspNetCore.Identity;

namespace Lexicon_LMS.Server.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int? CourseId { get; set; } = null!;

        //Relationer
        public Course Course { get; set; } = new Course();
        public ICollection<Assignments> Assignments { get; set; } = new List<Assignments>();

    }
}
