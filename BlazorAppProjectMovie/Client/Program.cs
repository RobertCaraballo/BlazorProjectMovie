using BlazorAppProjectMovie.Client;
using BlazorAppProjectMovie.Client.Repositorios;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tewr.Blazor.FileReader;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using FluentAssertions.Common;
using Fluent.Infrastructure.FluentModel;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

ConfigureSErvices(builder.Services);

await builder.Build().RunAsync();

static void ConfigureSErvices(IServiceCollection services)
{
    services.AddControllers();

    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

    services.AddSingleton<ServiciosSingleton>();
    services.AddTransient<ServiciosTransistorio>();
    services.AddSingleton<IRepositorio, Repositorio>();
    services.AddFileReaderService(options => options.InitializeOnFirstCall = true);

}


public class MyController
{
    private readonly ApplicationDbContext _context;

    public MyController(ApplicationDbContext context)
    {
        _context = context;
    }
}
