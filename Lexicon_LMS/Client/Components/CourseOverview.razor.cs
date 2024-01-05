using Lexicon_LMS.Shared.Models.Entities;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;


namespace Lexicon_LMS.Client.Components
{
    public partial class CourseOverview
    {
        [Inject]
        private HttpClient? Http { get; set; }

        private List<Courses>? courses;
        private string? ErrorMessage;

   
        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await Http!.GetFromJsonAsync<List<Courses>>("/api/Courses");

                if (response!= null)
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
