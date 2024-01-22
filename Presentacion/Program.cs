using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Presentacion;
using Presentacion.Servicios;
using Presentacion.Servicios.Interfaces;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//services 
builder.Services.AddScoped<IJugadoresService,JugadoresService>();
builder.Services.AddScoped<ITorneosService,TorneosService>();

//Radzen
builder.Services.AddRadzenComponents();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
