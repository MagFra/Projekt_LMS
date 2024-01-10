using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Lexicon_LMS.Shared.Domain.CoursesDTOs;


namespace Lexicon_LMS.Client.Components
{
    public partial class CourseOverview
    {
        [Inject]
        private HttpClient? Http { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Parameter]

        public string? CourseId { get; set; }

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

        private async Task Delete(int CourseId)
        {
            try
            {
                await Http!.DeleteAsync($"api/Courses/{CourseId}");

                // Refresh the current page to reflect the updated list
                NavigationManager!.NavigateTo(NavigationManager.Uri, forceLoad: true);
            }
            catch (Exception ex)
            {
                // Handle the error
                ErrorMessage = $"Error deleting course: {ex.Message}";
            }
        }

    }
}

