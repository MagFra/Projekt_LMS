using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Lexicon_LMS.Client.Components;
public partial class AddModule
{
    [Inject]
    private HttpClient? HttpClient { get; set; }

    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    private string? ErrorMessage;

    private CourseDTO? newModule = new CourseDTO()!;
   

    private async Task AddNewModule()
    {
        try
        {
            // Send a POST request to create the new course
            using var response = await HttpClient?.PostAsJsonAsync("/api/Modules", newModule)!;

            if (!response.IsSuccessStatusCode)
            {
                // Set error message for display, log to console, and return
                ErrorMessage = response.ReasonPhrase;
                Console.WriteLine($"There was an error! {ErrorMessage}");
                return;
            }

            // Convert response data to CourseDTO object
            newModule = await response.Content.ReadFromJsonAsync<CourseDTO>();

            // Redirect to CourseOverview page after successful creation
            NavigationManager?.NavigateTo("/listofmodules");
        }
        catch (Exception exception)
        {
            ErrorMessage = exception.Message;
        }
    }
}
