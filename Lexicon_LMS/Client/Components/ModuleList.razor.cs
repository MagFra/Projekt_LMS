using Lexicon_LMS.Shared.Domain.ModulesDTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Lexicon_LMS.Client.Components;

public partial class ModuleList
{
    [Inject]
    private HttpClient? Http { get; set; }

    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    private List<ModuleDTO>? modules;

    private string? errorMessage;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            modules = await Http!.GetFromJsonAsync<List<ModuleDTO>>("/api/Modules");
        }
        catch (Exception exception)
        {
            errorMessage = exception.Message;
        }
    }

    private async Task Delete(int? moduleId)
    {
        try
        {
            if (moduleId.HasValue)
            {
                var response = await Http!.DeleteAsync($"/api/Modules/{moduleId}");

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

