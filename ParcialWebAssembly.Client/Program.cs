using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ParcialWebAssembly.Client.Services;
using Shared.Interfaces;
using Shared.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IClientService<Articulos>, ArticuloService>();

await builder.Build().RunAsync();
