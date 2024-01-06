using Lexicon_LMS.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Lexicon_LMS.Client.Components;
public partial class AddCourse
{
    [Inject]
    private HttpClient? HttpClient { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private string? ErrorMessage;

    private CourseDTO newCourse = new CourseDTO();
   

    private async Task AddNewCourse()
    {
        try
        {
            // Send a POST request to create the new course
            using var response = await HttpClient.PostAsJsonAsync("/api/Courses", newCourse);

            if (!response.IsSuccessStatusCode)
            {
                // Set error message for display, log to console, and return
                ErrorMessage = response.ReasonPhrase;
                Console.WriteLine($"There was an error! {ErrorMessage}");
                return;
            }

            // Convert response data to CourseDTO object
            newCourse = await response.Content.ReadFromJsonAsync<CourseDTO>();

            // Redirect to CourseOverview page after successful creation
            NavigationManager.NavigateTo("/listofcourses");
        }
        catch (Exception exception)
        {
            ErrorMessage = exception.Message;
        }
    }
}
