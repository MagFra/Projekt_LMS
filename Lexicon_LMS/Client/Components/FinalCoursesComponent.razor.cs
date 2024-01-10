using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using Lexicon_LMS.Client.Pages;


namespace Lexicon_LMS.Client.Components
{
    public partial class FinalCoursesComponent
	{
        [Inject]
        private HttpClient? Http { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        [Parameter]
        public int? CourseId { get; set; }

        private CourseDTO? course = new CourseDTO();
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
        private async Task Delete()
        {
            try
            {
                // Fetch the course by its ID
                var courseToDelete = await Http!.GetFromJsonAsync<CourseDTO>($"/api/Courses/{CourseId}");

                // Check if the course was retrieved successfully
                if (courseToDelete != null)
                {
                    // Attempt to delete the course using the correct ID
                    var response = await Http!.DeleteAsync($"/api/Courses/{courseToDelete.Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        // Remove the course from the local list
                        courses!.Remove(courseToDelete);
                    }
                    else
                    {
                        ErrorMessage = "Could not delete course in API! " + response.StatusCode;
                    }
                }
                else
                {
                    ErrorMessage = "Could not retrieve course for deletion.";
                }
            }
            catch (Exception ex)
            {
                // Handle the error
                ErrorMessage = $"Error deleting course: {ex.Message}";
            }
        }



    }

}


