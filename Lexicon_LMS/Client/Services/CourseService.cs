using Lexicon_LMS.Client.Components;
using Lexicon_LMS.Client.Pages;
using Lexicon_LMS.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace Lexicon_LMS.Client.Services
{
    public class CourseService : ICourseService
    {
        public static List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
        public CourseService()
        {
            //Courses.Add(new Course() { CourseId = 1, , StartDate = DateTime.Now, DeviceType = "Sensor", Status = Status.online });

        }
        public List<CourseDTO> GetCourses()
        {
            return Courses;
        }

        public CourseDTO GetCourse(int Id)
        {
            return Courses.FirstOrDefault(x => x.Id == Id)!;
        }

        public CourseDTO GetDevice(int Id)
        {
            return Courses.FirstOrDefault(x => x.Id == Id)!;
        }


        //public void DeleteCourse(int Id)
        //{
        //    var Course = Courses.FirstOrDefault(x => x.Id == Id);
        //    if (Course != null)
        //    {
        //        CourseData.Delete(Course);
        //    }
        //}

        //public void UpdateCourse(CourseDTO updatedCourse)
        //{
        //    var course = Courses.FirstOrDefault(d => d.updatedCourse.CourseId == updatedCourse.CourseId);
        //    if (course != null)
        //    {
        //        course.Name = updatedCourse.Name;
        //        course.StartDate = updatedCourse.StartDate;
        //    }
        //}

        public void AddCourse(CourseDTO course)
        {
            Random rnd = new Random();
            course.Id = rnd.Next(100000);
            CourseData.Add(course);
        }
    }
}
