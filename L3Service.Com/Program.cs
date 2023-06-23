using Blazor.Core.Src;
using L3Service.Com;
using Microsoft.Extensions.Configuration;



IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices(services =>
    {
       
        services.AddHostedService<L3WorkerService>();
    })
    .Build();
var configurationService = host.Services.GetRequiredService<IConfiguration>();
var connectionString = configurationService.GetSection("ConnectionString").Get<ConnectionString>();
var dbProviders = configurationService.GetSection("DbProviders").Get<DbProviders>();
await host.RunAsync();
