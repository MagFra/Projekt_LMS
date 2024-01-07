using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexicon_LMS.Shared.Domain.ActivitiesDTOs;
using Lexicon_LMS.Shared.Domain.CoursesDTOs;

namespace Lexicon_LMS.Shared.Domain.ModulesDTOs
{
    public class ModuleDTO
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public int LengthOfDays { get; set; }

        public ICollection<ActivityDTO>? Activities { get; set; } = default!;

        public CourseDTO Course { get; set; } = null!;

    }
}
