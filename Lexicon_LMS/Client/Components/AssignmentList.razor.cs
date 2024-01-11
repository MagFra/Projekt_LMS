using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Lexicon_LMS.Shared.Domain.AssignmetsDTOs;


namespace Lexicon_LMS.Client.Components;

public partial class AssignmentList
{
    [Inject]
    private HttpClient? Http { get; set; }

    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    private List<AssignmentDTO>? assignments;

    private string? ErrorMessage;


    protected override async Task OnInitializedAsync()
    {
        try
        {
            var response = await Http!.GetFromJsonAsync<List<AssignmentDTO>>("/api/activities");

            if (response != null)
            {
                assignments = response;
            }
            else
            {
                ErrorMessage = "Could not read assignments from API!";
            }
        }
        catch (Exception exception)
        {
            ErrorMessage = exception.Message;
        }
    }
}


