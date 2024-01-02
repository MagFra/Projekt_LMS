using Microsoft.AspNetCore.Identity;

namespace Lexicon_LMS.Server.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int? CourseId { get; set; } = null!;

        //Relationer
        public Courses Course { get; set; } = new Courses();
        public ICollection<Assignments> Assignments { get; set; } = new List<Assignments>();

    }
}
