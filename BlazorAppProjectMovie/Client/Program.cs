using BlazorAppProjectMovie.Client;
using BlazorAppProjectMovie.Client.Repositorios;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

ConfigureSErvices(builder.Services);

await builder.Build().RunAsync();

static void ConfigureSErvices(IServiceCollection services)
{

    services.AddSingleton<ServiciosSingleton>();
    services.AddTransient<ServiciosTransistorio>();
    services.AddSingleton<IRepositorio, Repositorio>();

}
