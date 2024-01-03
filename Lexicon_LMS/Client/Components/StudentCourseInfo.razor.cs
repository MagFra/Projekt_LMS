using Lexicon_LMS.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lexicon_LMS.Client.Components

{
    public partial class StudentCourseInfo
    {
        //public CourseDTO CourseInfo { get; set; } //= new CourseDTO();

        public ModuleDTO Module { get; set; }

        //public async List<ModuleDTO> ModuleDTOs()
        //{
        //    return await _context
        //}


    }
}
