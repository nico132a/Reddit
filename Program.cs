using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoListBlazor;
using shared.model;
using PostdataBlazor.Data;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { 
  BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
}); 
builder.Services.AddSingleton<PostDataService>();
await builder.Build().RunAsync();
