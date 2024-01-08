using Lexicon_LMS.Shared.Domain.ModulesDTOs;
using Microsoft.EntityFrameworkCore;

namespace Lexicon_LMS.Client.Components

{
    public partial class StudentCourseInfo
    {
        //public CourseDTO CourseInfo { get; set; } //= new CourseDTO();

        public List<ModuleDTO> Module { get; set; } = new List<ModuleDTO> { new ModuleDTO {
                                                                                Name = "Test",
                                                                                Description = "fhgvfhb",
                                                                                StartDate = DateTime.Now,
                                                                                LengthOfDays = 5,
                                                                           } };

        //public async List<ModuleDTO> ModuleDTOs()
        //{
        //    return await _context
        //}


    }
}
