using Lexicon_LMS.Client.Components;
using Lexicon_LMS.Client.Pages;
using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using Microsoft.AspNetCore.Components;

namespace Lexicon_LMS.Client.Services
{
    public interface ICourseService
        {
            List<CourseDTO> GetCourses();

            CourseDTO GetCourse(int Id);

            //void DeleteCourse(int Id);

            //void UpdateCourse(CourseDTO Course);

            void AddCourse(CourseDTO Course);
        }
}