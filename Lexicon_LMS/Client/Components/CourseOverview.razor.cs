using Lexicon_LMS.Shared.Domain;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;


namespace Lexicon_LMS.Client.Components
{
    public partial class CourseOverview
    {
        [Inject]
        private HttpClient? Http { get; set; }

        private List<CourseDTO>? courses;
        private string? ErrorMessage;


        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await Http!.GetFromJsonAsync<List<CourseDTO>>("/api/Courses");

                if (response != null)
                {
                    courses = response;
                }
                else
                {
                    ErrorMessage = "Could not read courses from API!";
                }
            }
            catch (Exception exception)
            {
                ErrorMessage = exception.Message;
            }
        }

    }
}

//using Lexicon_LMS.Shared.Models.Entities;
//using System.Net.Http.Json;
//using Microsoft.AspNetCore.Components;

//@inject CourseDataService CourseDataService

//namespace Lexicon_LMS.Client.Components;
//public partial class CourseOverview
//{
//             [Inject]
//        private HttpClient? Http { get; set; }
//    protected override async Task OnInitializedAsync()
//    {
//        try
//        {
//            courses = await CourseDataService.GetCoursesAsync();
//        }
//        catch (Exception exception)
//        {
//            ErrorMessage = "An error occurred while loading the course data. Please try again later or contact support.";
//        }
//    }
//}
