
using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;

namespace Lexicon_LMS.Client.Pages;

public partial class CourseDelete
{

    [Inject]
    private HttpClient? Http { get; set; }

    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    [Parameter]
    public int CourseId { get; set; }

    private CourseDTO course = new CourseDTO();

    public string responseData = string.Empty;

    public string ErrorMessage = string.Empty;


    protected override async Task OnInitializedAsync()
    {
        try
        {
           
            course = await Http!.GetFromJsonAsync<CourseDTO>($"/api/Courses/{CourseId}");
            if ( course == null )
            {
                return;
            }
              
        }
        catch (Exception exception)
        {
            ErrorMessage = exception.Message;
        }
        await base.OnInitializedAsync();
    }


private async Task Delete()
        {
        try
        {
            var response = await Http!.DeleteAsync($"/api/Courses/" + course.Id);
            if (response.IsSuccessStatusCode)
            {
                NavigationManager!.NavigateTo($"/ListOfCourses");
            }
            else
            {
                ErrorMessage = "Could not delete course in API! " + response.StatusCode;

            }
        }
        catch (Exception ex)
        {
            // Handle the error
            ErrorMessage = $"Error deleting course: {ex.Message}";
        }
     }

   }





