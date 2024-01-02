using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_LMS.Shared.Domain
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public int LenthDays { get; set; }


        // Foreign key
        public int ModuleId { get; set; }


        // Navigation property
        public ModuleDTO Module { get; set; } = new ModuleDTO();
        public ICollection<AssignmentDTO> ListOfAssignments { get; set; } = new List<AssignmentDTO>();
    }
}
