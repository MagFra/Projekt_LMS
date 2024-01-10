using Lexicon_LMS.Shared.Domain.ActivitiesDTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Lexicon_LMS.Client.Components;

public partial class ActivityList
{
    [Inject]
    private HttpClient? Http { get; set; }

    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    private List<ActivityDTO>? activities;

    private string? errorMessage;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            activities = await Http!.GetFromJsonAsync<List<ActivityDTO>>("/api/activities");
        }
        catch (Exception exception)
        {
            errorMessage = exception.Message;
        }
    }

    private async Task Delete(int? activityId)
    {
        try
        {
            if (activityId.HasValue)
            {
                var response = await Http!.DeleteAsync($"/api/Modules/{activityId}");

                if (response.IsSuccessStatusCode)
                {
                    // Refresh the current page to reflect the updated list
                    StateHasChanged();
                }
                else
                {
                    errorMessage = "Could not delete module in API! " + response.StatusCode;
                }
            }
            else
            {
                errorMessage = "Module Id is null or invalid.";
            }
        }
        catch (Exception ex)
        {
            // Handle the error
            errorMessage = $"Error deleting module: {ex.Message}";
        }
    }
}

