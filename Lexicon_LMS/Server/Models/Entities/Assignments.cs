using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_LMS.Server.Models.Entities
{
    public class Assignments
    {
        public string Description { get; set; } = string.Empty;

        //Foreign Keys
        public int ActivityId { get; set; }
        public string ApplicationUserId { get; set; } = default!;


        //Navigation Properties
        public Activities? Activity { get; set; } = null!;
        public ApplicationUser? Student { get; set; } = null!;
    }
}