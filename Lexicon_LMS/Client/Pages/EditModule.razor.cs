using Lexicon_LMS.Shared.Domain.ModulesDTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Lexicon_LMS.Client.Pages
{
    public partial class EditModule
    {
        [Inject]
        private HttpClient? HttpClient { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        private string? ErrorMessage;

        private ModuleDTO Module = new ModuleDTO()!;

        [Parameter]
        public int ModuleId { get; set; }

        protected override async Task OnInitializedAsync()
        {

        }

        private async Task UpdateModule()
        {
            try
            {
                Module.Id = ModuleId;

                // Send a POST request to create the new module
                using var response = await HttpClient?.PostAsJsonAsync("/api/Modules", Module)!;

                if (!response.IsSuccessStatusCode)
                {
                    // Set error message for display, log to console, and return
                    ErrorMessage = response.ReasonPhrase;
                    Console.WriteLine($"There was an error! {ErrorMessage}");
                    return;
                }

                // Convert response data to ModuleDTO object
                Module = await response.Content.ReadFromJsonAsync<ModuleDTO>();

                // Redirect to ModuleOverview page after successful creation
                NavigationManager.NavigateTo($"/coursedetails/{Module.CourseId}");
            }
            catch (Exception exception)
            {
                ErrorMessage = $"Could not add module! {exception.Message})";
            }
        }
    }
}
