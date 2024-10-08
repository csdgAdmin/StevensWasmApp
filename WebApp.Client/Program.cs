using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebApp.Client;
using WebApp.Client.Services;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<ILoginService, LoginService>(client => {
    client.BaseAddress = new Uri((builder.HostEnvironment.BaseAddress));
});

//builder.Services.AddSingleton<ILoginService, LoginService>();

await builder.Build().RunAsync();
