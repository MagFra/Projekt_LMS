using Lexicon_LMS.Shared.Domain.ModulesDTOs;
using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Lexicon_LMS.Client.Components

{
    public partial class StudentCourseInfo
    {
        public List<CourseDTO> Courses { get; set; } = default!;

    }
}
