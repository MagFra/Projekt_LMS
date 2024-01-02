using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_LMS.Shared.Domain
{
    public class ModuleListDTO
    {
        public ICollection<ModuleDTO> ListOfModules { get; set; } = new List<ModuleDTO>();
    }
}
