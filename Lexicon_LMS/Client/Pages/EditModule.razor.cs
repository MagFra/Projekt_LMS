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
                var response = await HttpClient!.GetFromJsonAsync<ModuleForUpdateDTO>($"api/modules/{ModuleId}");

                if (response != null)
                {
                    Module = response;
                }
                else
                {
                    ErrorMessage = "Could not read module from API!";
                }
            }
            catch (Exception exception)
            {
                ErrorMessage = exception.Message;
            }

            await base.OnInitializedAsync();
        }

        private async Task HandleValidSubmit()
        {
            try
            {
                // Use the existing 'course' object for making updates
                var success = await HttpClient.PutAsJsonAsync($"/api/modules/{ModuleId}", Module);

                if (success.IsSuccessStatusCode)
                {
                    NavigationManager!.NavigateTo("/listofcourses"); // Redirect to the course overview after a successful edit
                }
                else
                {
                    ErrorMessage = "Failed to update the module!";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
            }
        }


    }
}
