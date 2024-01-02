using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_LMS.Shared.Domain
{
    public class CourseListDTO
    {
        public ICollection<CourseDTO> ListOfCourses { get; set; } = new List<CourseDTO>();
    }
}
