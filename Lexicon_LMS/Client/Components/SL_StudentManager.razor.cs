using Lexicon_LMS.Client.Pages;
using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using Lexicon_LMS.Shared.Domain.UsersDTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System.Net.Http.Json;

namespace Lexicon_LMS.Client.Components
{
	public partial class SL_StudentManager
	{
		[Inject]
		private HttpClient? Http { get; set; }

		private List<UserDTO>? _users;
		private string? ErrorMessage;

		protected override async Task OnInitializedAsync()
		{
			try
			{
				var response = await Http!.GetFromJsonAsync<List<UserDTO>>("/api/Users");

				if (response != null)
				{
					_users = response;
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
}
