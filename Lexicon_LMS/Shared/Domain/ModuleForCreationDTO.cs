using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_LMS.Shared.Domain
{
    public class ModuleForCreationDTO
    {
        [Required]
        public int CourseId { get; set; }


        [Required]
        public string Name { get; set; } = default!;


        [Required]
        public string Description { get; set; } = default!;


        [Required]
        public DateTime StartDate { get; set; }


        [Required, Range(1, 365)]
        public int LengthOfDays { get; set; }
    }
}
