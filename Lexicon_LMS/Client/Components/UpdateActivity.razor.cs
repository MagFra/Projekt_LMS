using Lexicon_LMS.Shared.Domain.ActivitiesDTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Lexicon_LMS.Client.Components;

public partial class UpdateActivity
{
    [Inject]
    public HttpClient? HttpClient { get; set; }
    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    [Parameter]
    public int ActivityId { get; set; }

    private ActivityDTO? Activity { get; set; } = new ActivityDTO();
    private string ErrorMessage = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            // Fetch the existing Activity details only once when the component initializes
            Activity = await HttpClient!.GetFromJsonAsync<ActivityDTO>($"/api/activities/{ActivityId}");
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    private async Task HandleValidSubmit()
    {
        try
        {
            // Use the existing 'Activity' object for making updates
            var success = await HttpClient!.PutAsJsonAsync($"/api/activities/{ActivityId}", Activity);

            if (success.IsSuccessStatusCode)
            {
                NavigationManager!.NavigateTo("/listofactivities"); // Redirect to the Activity overview after a successful edit
            }
            else
            {
                ErrorMessage = "Failed to update the course!";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage += ex.Message;
        }
    }

    private void InvalidFormSubmitted()
    {

        ErrorMessage = "Failed to update the course!";

    }


}
