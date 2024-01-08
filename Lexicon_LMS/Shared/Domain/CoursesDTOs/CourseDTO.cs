using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lexicon_LMS.Shared.Domain.UsersDTOs;

namespace Lexicon_LMS.Shared.Domain.CoursesDTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public int LengthDays { get; set; }
        public DateTime LastApplicationDay { get; set; }

        // Navigation properties
        public ICollection<Module>? ModuleList { get; set; } = null!;

        public ICollection<UserDTO>? StudentList { get; set; } = null!;

    }
}
