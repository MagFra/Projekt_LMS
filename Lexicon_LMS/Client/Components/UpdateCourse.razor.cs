using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Lexicon_LMS.Client.Components;

public partial class UpdateCourse
{
    [Inject]
    private HttpClient HttpClient { get; set; } = new HttpClient();
    [Inject]
    private NavigationManager NavigationManager { get; set; } = null;

    [Parameter]
    public int Id { get; set; }

    private CourseDTO? course;

    private string? ErrorMessage;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            course = await HttpClient.GetFromJsonAsync<CourseDTO>($"/api/courses/{Id}");
        } catch (Exception ex) 
        {
            ErrorMessage = ex.Message;
        }
    }
    private async Task EditCourse()
    {
        try
        {
            var response = await HttpClient.PutAsJsonAsync($"/api/courses/{Id}", course);

            if (response.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/courseoverview");// Redirect to course overview after successful edit
            }
            else
            {
                ErrorMessage = "Failed to update course!";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage += ex.Message;
        }
    }
}