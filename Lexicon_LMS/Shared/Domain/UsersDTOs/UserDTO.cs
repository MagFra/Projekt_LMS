using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexicon_LMS.Shared.Domain.AssignmetsDTOs;
using Lexicon_LMS.Shared.Domain.CoursesDTOs;

namespace Lexicon_LMS.Shared.Domain.UsersDTOs
{
    public class UserDTO
    {
        [Key, MaxLength(450)]
        public string Id { get; set; } = string.Empty;
        [Required, MaxLength(256)]
        public string UserName { get; set; } = string.Empty;
        [Required, MaxLength(256)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public bool EmailConfirmed { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int? CourseId { get; set; } = null!;

        //Relationer
        public CourseDTO Course { get; set; } = new CourseDTO();
        public ICollection<AssignmentDTO> ListOfAssignments { get; set; } = new List<AssignmentDTO>();

    }
}
