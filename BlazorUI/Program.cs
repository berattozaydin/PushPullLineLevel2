global using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Blazored.LocalStorage;
using BlazorUI.Api;
using BlazorUI.Src;
using BlazorUI.StateStore;
using BlazorUI;
using BlazorDAL.Models;
using Havit.Blazor.Components.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CustomerOrderApi>();
builder.Services.AddScoped<AuthApi>();
builder.Services.AddScoped<EvtAlmApi>();
builder.Services.AddScoped<DelayApi>();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IHttpClient>(sp =>
{

    var a = new Axios { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
    a.OnResponse += async (jsonResponse) =>
    {
        DialogService dialogService = sp.GetService<DialogService>();

        if (dialogService == null) return;

        var data = jsonResponse.Data;

        if (data.GetType().Name.Contains(nameof(ReturnResult)) == false)
        {
            return;
        }


        var msg = data.GetType().GetProperty(nameof(ReturnResult.Msg))!.GetValue(data) as string;
        var isSuccess = data.GetType().GetProperty(nameof(ReturnResult.IsSuccess))!.GetValue(data) as int?;


        if (isSuccess == 1 && jsonResponse.HttpResponseMessage.RequestMessage.Method != HttpMethod.Get)
            await dialogService.Alert(msg, "Ýþlem Baþarýlý", new AlertOptions { OkButtonText = "Kapat" });
        else if (isSuccess == 0)
            await dialogService.Alert(msg, "Hata", new AlertOptions { OkButtonText = "Kapat" });

    };
    return a;
});
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddHxServices();
System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
customCulture.NumberFormat.NumberDecimalSeparator = ".";
Thread.CurrentThread.CurrentCulture = customCulture;
//builder.Services.AddHxServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();



await builder.Build().RunAsync();
