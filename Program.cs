using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EventEase;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Determine the base address, including handling GitHub Pages paths
var baseAddress = builder.HostEnvironment.BaseAddress;
Console.WriteLine($"Base Address: {baseAddress}");

// Register the services
builder.Services.AddSingleton<EventEase.Services.UserStateService>();
builder.Services.AddSingleton<EventEase.Services.EventService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add this code for GitHub Pages routing
builder.Services.AddSingleton(new HttpClient
{
    BaseAddress = new Uri(baseAddress)
});

await builder.Build().RunAsync();
