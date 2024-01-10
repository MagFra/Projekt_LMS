using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_LMS.Shared.Domain.ModulesDTOs
{
    public class ModuleListDTO
    {
        public int? CourseId { get; set; } = null!;
        public CourseLimitedDTO? Course { get; set; } = null!;
        public IEnumerable<ModuleDTO>? ListOfModules { get; set; } = null!;
    }
}
