using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_LMS.Shared.Domain
{
    public class AssignmentsListDTO
    {
        public ICollection<AssignmentDTO> ListOfAssignments { get; set; } = new List<AssignmentDTO>();
    }
}
