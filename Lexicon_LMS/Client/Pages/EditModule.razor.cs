using Lexicon_LMS.Shared.Domain.CoursesDTOs;
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

        private ModuleForUpdateDTO Module = new ModuleForUpdateDTO()!;

        [Parameter]
        public int ModuleId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                // Fetch the existing course details only once when the component initializes
                Module = await HttpClient.GetFromJsonAsync<ModuleForUpdateDTO>($"/api/Modules/{ModuleId}");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private async Task UpdateModule()
        {
            try
            {
                // Send a PUT request to create the new module
                using var response = await HttpClient.PutAsJsonAsync($"/api/Modules/{ModuleId}", Module)!;

                if (!response.IsSuccessStatusCode)
                {
                    // Set error message for display, log to console, and return
                    ErrorMessage = response.ReasonPhrase;
                    Console.WriteLine($"There was an error! {ErrorMessage}");
                    return;
                }

                // Convert response data to ModuleForUpdateDTO object
                //Module = await response.Content.ReadFromJsonAsync<ModuleForUpdateDTO>();

                // Redirect to ModuleOverview page after successful creation
                NavigationManager!.NavigateTo($"/coursedetails/{Module.CourseId}");
            }
            catch (Exception exception)
            {
                ErrorMessage = $"Could not add module! {exception.Message})";
            }
        }
    }
}
