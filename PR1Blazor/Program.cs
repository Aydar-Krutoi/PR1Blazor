using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PR1Blazor;
using PR1Blazor.ApiRequest;
using PR1Blazor.ApiRequest.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5115")
});
builder.Services.AddScoped<RequestApi>();
builder.Services.AddScoped<UserSession>();

await builder.Build().RunAsync();