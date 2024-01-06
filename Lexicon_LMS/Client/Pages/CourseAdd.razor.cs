using Lexicon_LMS.Client.Services;
using Lexicon_LMS.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Xml.Schema;
using Microsoft.AspNetCore.Authorization;

namespace Lexicon_LMS.Client.Pages
{
    [Authorize(Roles = "Admin")]
    public partial class CourseAdd
    {
        [Inject]
        public CourseService CourseService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CourseDTO Course { get; set; } = new CourseDTO();

        public string responseData = string.Empty;

        public string ErrorMessage = string.Empty;

        private async Task HandleValidSubmit()
        {
            try
            {
                // JWT Token Bearer
                Http.DefaultRequestHeaders.Clear();
                Http.DefaultRequestHeaders.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Impfa19iIiwic3ViIjoial9rX2IiLCJqdGkiOiJjOGZhOThjZiIsInJvbGUiOiJBZG1pbiIsImF1ZCI6WyJodHRwOi8vbG9jYWxob3N0OjIyNjUzIiwiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMjEiLCJodHRwOi8vbG9jYWxob3N0OjUxODkiLCJodHRwczovL2xvY2FsaG9zdDo3MTMxIl0sIm5iZiI6MTcwMzIyOTA4NSwiZXhwIjoxNzExMDkxNDg1LCJpYXQiOjE3MDMyMjkwODYsImlzcyI6ImRvdG5ldC11c2VyLWp3dHMifQ.Qu8qHWqieMzwMpO7VFyIwhCVWQUuPPZOPTcfi4IBy8M");
                Http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonSerializer.Serialize(Course);
                var httpContent = new StringContent(json, new MediaTypeHeaderValue("application/json"));
                var response = await Http.PostAsync("/course/add", httpContent);
                if (response.IsSuccessStatusCode)
                {
                    responseData = await response.Content.ReadAsStringAsync();
                    NavigationManager.NavigateTo($"courses");
                }
                else
                {
                    ErrorMessage = "Could not add Course in API! " + response.StatusCode;
                }
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message + " " + ex.HResult;
            }

        }
    }
}
