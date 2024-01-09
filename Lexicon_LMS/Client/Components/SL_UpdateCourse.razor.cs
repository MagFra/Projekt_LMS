using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Lexicon_LMS.Client.Components;

public partial class SL_UpdateCourse
{
    [Inject]
    public HttpClient? HttpClient { get; set; }
    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    [Parameter]
    public int CourseId { get; set; }

    private CourseDTO? Course { get; set; } = new CourseDTO();
    private string ErrorMessage = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            // Fetch the existing course details only once when the component initializes
            Course = await HttpClient!.GetFromJsonAsync<CourseDTO>($"/api/courses/{CourseId}");
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
            // Use the existing 'course' object for making updates
            var success = await HttpClient!.PutAsJsonAsync($"/api/courses/{CourseId}", Course);
            
            if (success.IsSuccessStatusCode)
            {
                NavigationManager!.NavigateTo("/listofcourses"); // Redirect to the course overview after a successful edit
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

    private async Task InvalidFormSubmitted()
    {
     
      ErrorMessage = "Failed to update the course!";
            
    }
}
