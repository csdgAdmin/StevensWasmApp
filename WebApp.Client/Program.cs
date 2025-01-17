using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebApp.Client;
using WebApp.Client.Services;
using static WebApp.Shared.CommonConstants;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<ILoginService, LoginService>(client => {
    client.BaseAddress = new(DevServerUri);
});
builder.Services.AddHttpClient<IUserService, UserService>(client => {
    client.BaseAddress = new(DevServerUri);
});

builder.Services.AddBlazoredSessionStorageAsSingleton();

await builder.Build().RunAsync();
