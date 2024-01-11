using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lexicon_LMS.Shared.Domain.AssignmetsDTOs;
using Lexicon_LMS.Shared.Domain.ModulesDTOs;

namespace Lexicon_LMS.Shared.Domain.ActivitiesDTOs
{
    public class ActivityLimitedDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public int LenthDays { get; set; }
    }
}
