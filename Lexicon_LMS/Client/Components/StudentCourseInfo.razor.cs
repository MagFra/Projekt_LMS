using Lexicon_LMS.Shared.Domain.ModulesDTOs;
using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Lexicon_LMS.Shared.Domain.UsersDTOs;
using Lexicon_LMS.Client.Pages;
using System.Net.Http.Json;

namespace Lexicon_LMS.Client.Components

{
    public partial class StudentCourseInfo
    {
        [Inject]
        private HttpClient? Http { get; set; }
        private List<CourseDTO>? _courses;
        
        private string? ErrorMessage;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await Http!.GetFromJsonAsync<List<CourseDTO>>("/api/Courses");

                if (response != null)
                {
                    _courses = response;
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
