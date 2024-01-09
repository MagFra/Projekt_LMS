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
        public int? ActivityId { get; set; } = null!;
        public string? ApplicationUserId { get; set; } = null!;


        //Navigation Properties
        public ActivityDTO? Activity { get; set; } = null!;
        public UserDTO? Student { get; set; } = null!;

    }
}
