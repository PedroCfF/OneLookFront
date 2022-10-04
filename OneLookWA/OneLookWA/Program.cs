using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OneLookWA;
using OneLookWA.Services.Projects;
using OneLookWA.Services.Users;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IProjectsService, ProjectsServicecs>();

await builder.Build().RunAsync();
