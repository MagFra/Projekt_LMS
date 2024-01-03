using Lexicon_LMS.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace ManagementCentral.Client.Services
{
    public class ICourseService
    {
        public static List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
        public ICourseService() 
        {
            //Courses.Add(new Device() { DeviceId = 1, Location = Location.Sweden, Date = DateTime.Now, DeviceType = "Sensor", Status = Status.online });
            //Courses.Add(new Device() { DeviceId = 2, Location = Location.England, Date = DateTime.Now, DeviceType = "Machine", Status = Status.offline });
            //Courses.Add(new Device() { DeviceId = 3, Location = Location.Sweden, Date = DateTime.Now, DeviceType = "Sensor", Status = Status.online });
        }

        private void ViewCourse(int courseId)
        {
            NavigationManager.NavigateTo($"/view/{courseId}");
        }

        private void EditCourse(int courseId)
        {
            NavigationManager.NavigateTo($"/edit/{courseId}");
        }

        private void DeleteCourse(int courseId)
        {
            CourseService.DeleteCourse(courseId);
            StateHasChanged(); // Update the UI
        }
    }
}
