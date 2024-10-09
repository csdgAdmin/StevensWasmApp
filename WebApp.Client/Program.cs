using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebApp.Client;
using WebApp.Client.Services;
using static WebApp.Client.Common.ClientConstants;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Client.Common;
using Blazored.SessionStorage;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<ILoginService, LoginService>(client => {
    client.BaseAddress = new(ClientConstants.DevServerUri);
});
builder.Services.AddHttpClient<IUserService, UserService>(client => {
    client.BaseAddress = new(ClientConstants.DevServerUri);
});

builder.Services.AddBlazoredSessionStorageAsSingleton();

await builder.Build().RunAsync();
