using GestionStock.SPA;
using GestionStock.SPA.Infrastructure.Brand;
using GestionStock.SPA.Infrastructure.Category;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["GatewayUrl"]) });
builder.Services.AddTransient<IBrandManager, BrandManager>();
builder.Services.AddTransient<ICategoryManager, CategoryManager>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
