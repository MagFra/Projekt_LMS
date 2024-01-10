using Lexicon_LMS.Shared.Domain.ActivitiesDTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Lexicon_LMS.Client.Components;
public partial class AddActivity
{
    [Inject]
    private HttpClient? HttpClient { get; set; }

    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    private string? ErrorMessage;

    private ActivityDTO? newActivity = new ActivityDTO()!;


    private async Task AddNewActivity()
    {
        try
        {
            // Send a POST request to create the new activity
            using var response = await HttpClient?.PostAsJsonAsync("/api/activities", newActivity)!;

            if (!response.IsSuccessStatusCode)
            {
                // Set error message for display, log to console, and return
                ErrorMessage = response.ReasonPhrase;
                Console.WriteLine($"There was an error! {ErrorMessage}");
                return;
            }

            // Convert response data to ActivityDTO object
            newActivity = await response.Content.ReadFromJsonAsync<ActivityDTO>();

            // Redirect to CourseOverview page after successful creation
            NavigationManager?.NavigateTo("/listofactivities");
        }
        catch (Exception exception)
        {
            ErrorMessage = exception.Message;
        }
    }
}
