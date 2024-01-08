using Lexicon_LMS.Client.Components;
using Lexicon_LMS.Client.Pages;
using Lexicon_LMS.Server.Services;
using Lexicon_LMS.Shared.Domain.ModulesDTOs;
using Microsoft.AspNetCore.Components;

namespace Lexicon_LMS.Client.Services
{
    public class ModuleService : IModuleService
    {
        public static List<ModuleDTO> Modules { get; set; } = new List<ModuleDTO>();
        public ModuleService()
        {
            //Courses.Add(new Course() { CourseId = 1, , StartDate = DateTime.Now, DeviceType = "Sensor", Status = Status.online });

        }
        public List<ModuleDTO> GetModules()
        {
            return Modules;
        }

        public ModuleDTO GetModule(int Id)
        {
            return Modules.FirstOrDefault(x => x.Id == Id)!;
        }

        public ModuleDTO GetDevice(int Id)
        {
            return Modules.FirstOrDefault(x => x.Id == Id)!;
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

        public void AddModule(ModuleDTO module)
        {
            Random rnd = new Random();
            module.Id = rnd.Next(100000);
            ModuleData.Add(module);
        }
    }
}