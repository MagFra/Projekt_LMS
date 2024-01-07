using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexicon_LMS.Shared.Domain.ActivitiesDTOs;
using Lexicon_LMS.Shared.Domain.UsersDTOs;

namespace Lexicon_LMS.Shared.Domain.AssignmetsDTOs
{
    public class AssignmentDTO
    {
        public string Description { get; set; } = string.Empty;

        //Foreign Keys
        public int ActivityId { get; set; }
        public string ApplicationUserId { get; set; } = default!;


        //Navigation Properties
        public ActivityDTO Activity { get; set; } = new ActivityDTO();
        public UserDTO Student { get; set; } = new UserDTO();

    }
}
