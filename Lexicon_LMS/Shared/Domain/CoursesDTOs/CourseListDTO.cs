using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_LMS.Shared.Domain.CoursesDTOs
{
    public class CourseListDTO
    {
        public IEnumerable<CourseDTO> ListOfCourses { get; set; } = new List<CourseDTO>();
    }
}
