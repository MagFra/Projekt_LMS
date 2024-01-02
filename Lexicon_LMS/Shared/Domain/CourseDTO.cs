using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_LMS.Shared.Domain
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
        public ICollection<Module> ModuleList { get; set; } = new List<Module>();

        public ICollection<UserDTO> StudentList { get; set; } = new List<UserDTO>();

    }
}
