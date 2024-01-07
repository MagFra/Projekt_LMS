using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_LMS.Shared.Domain.ModulesDTOs
{
    public class ModuleListDTO
    {
        public IEnumerable<ModuleDTO>? ListOfModules { get; set; } = default!;
    }
}
