using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Lexicon_LMS.Client.Pages;

public partial class CourseDetails
{
    [Inject]
    public HttpClient? HttpClient { get; set; }

    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    [Parameter]
    public int courseId { get; set; }

    private CourseDTO? course;

    private string? ErrorMessage;
    protected override async Task OnInitializedAsync()
    {
        try
        {
            var response = await HttpClient!.GetFromJsonAsync<CourseDTO>($"api/courses/{courseId}");

            if (response != null)
            {
                course = response;
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
}
