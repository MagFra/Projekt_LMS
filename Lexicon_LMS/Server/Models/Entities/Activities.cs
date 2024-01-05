using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_LMS.Server.Models.Entities
{
    public class Activities
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public int LenthDays { get; set; }


        // Foreign key
        public int ModuleId { get; set; }


        // Navigation property
        public Module Module { get; set; } = new Module();
        public ICollection<Assignments> AssignmentsLista { get; set; } = new List<Assignments>();
    }
}
