using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lexicon_LMS.Shared.Domain.UsersDTOs;

namespace Lexicon_LMS.Shared.Domain.CoursesDTOs
{
    public class CourseLimitedDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public int LengthDays { get; set; }
    }
}
