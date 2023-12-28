using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_LMS.Shared.Domain
{
    public class Assignments
    {
        public string Description { get; set; } = string.Empty;

        //Foreign Keys
        public int ActivityId { get; set; }
        public string ApplicationUserId { get; set; } = default!;


        //Navigation Properties
        public Activity Activity { get; set; } = new Activity();
        public ApplicationUser Student { get; set; } = new ApplicationUser();
    }
}