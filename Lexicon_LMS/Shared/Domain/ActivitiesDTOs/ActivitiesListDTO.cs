using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_LMS.Shared.Domain.ActivitiesDTOs
{
    public class ActivitiesListDTO
    {
        public ICollection<ActivityDTO> ListOfActivities { get; set; } = new List<ActivityDTO>();
    }
}
