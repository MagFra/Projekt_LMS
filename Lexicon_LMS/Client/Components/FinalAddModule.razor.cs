﻿using Lexicon_LMS.Shared.Domain.ModulesDTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Lexicon_LMS.Client.Components;
public partial class FinalAddModule
{
    [Inject]
    private HttpClient? HttpClient { get; set; }

    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    private string? ErrorMessage;

    private ModuleForCreationDTO newModule = new ModuleForCreationDTO()!;

    [Parameter]
    public int CourseId { get; set; }


    private async Task AddNewModule()
    {
        try
        {
            newModule.CourseId = CourseId;
            // Send a POST request to create the new module
            using var response = await HttpClient?.PostAsJsonAsync("/api/Modules", newModule)!;

            if (!response.IsSuccessStatusCode)
            {
                // Set error message for display, log to console, and return
                ErrorMessage = response.ReasonPhrase;
                Console.WriteLine($"There was an error! {ErrorMessage}");
                return;
            }

            // Convert response data to ModuleDTO object
            newModule = await response.Content.ReadFromJsonAsync<ModuleForCreationDTO>();

            // Redirect to ModuleOverview page after successful creation
            NavigationManager!.NavigateTo($"/coursedetails/{CourseId}");
        }
        catch (Exception exception)
        {
            ErrorMessage = $"Could not add module! {exception.Message})";
        }
    }
}
