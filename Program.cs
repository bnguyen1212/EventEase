using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EventEase;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Determine the base address, including handling GitHub Pages paths
var baseAddress = builder.HostEnvironment.BaseAddress;
Console.WriteLine($"Base Address: {baseAddress}");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

// Register the services
builder.Services.AddSingleton<EventEase.Services.UserStateService>();
builder.Services.AddSingleton<EventEase.Services.EventService>();

await builder.Build().RunAsync();
