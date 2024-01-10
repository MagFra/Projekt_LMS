using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Lexicon_LMS.Shared.Domain.CoursesDTOs;


namespace Lexicon_LMS.Client.Components;

public partial class CourseOverview
{
    [Inject]
    private HttpClient? Http { get; set; }

    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    private List<CourseDTO>? courses;

    private string? ErrorMessage;


    protected override async Task OnInitializedAsync()
    {
        try
        {
            var response = await Http!.GetFromJsonAsync<List<CourseDTO>>("/api/Courses");

            if (response != null)
            {
                courses = response;
            }
            else
            {
                ErrorMessage = "Could not read courses from API!";
            }
        }
        catch (Exception exception)
        {
            ErrorMessage = exception.Message;
        }
    }

    private async Task Delete(int? courseId)
    {
        try
        {
            if (courseId.HasValue)
            {
                var response = await Http!.DeleteAsync($"/api/Modules/{courseId}");

                if (response.IsSuccessStatusCode)
                {
                    // Refresh the current page to reflect the updated list
                    StateHasChanged();

                }
                else
                {
                    ErrorMessage = "Could not delete module in API! " + response.StatusCode;
                }
            }
            else
            {
                ErrorMessage = "Module Id is null or invalid.";
            }
        }
        catch (Exception ex)
        {
            // Handle the error
            ErrorMessage = $"Error deleting module: {ex.Message}";
        }
    }



}


