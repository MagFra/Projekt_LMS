using Lexicon_LMS.Client;
using Lexicon_LMS.Client.Services;
using Lexicon_LMS.Server.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("Lexicon_LMS.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Lexicon_LMS.ServerAPI"));

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IModuleServiceClient, ModuleServiceClient>();

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
