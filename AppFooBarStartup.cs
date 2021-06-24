using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using P03DomainModels;
using P03DomainModels.Context;
using P03DomainModels.Options;

// Simple Service configured via Dependency Injection with Configuration Loaded
public class AppFooBarStartup :
  BaseStartup,
  IStartupConfigureServices
{
  public void ConfigureServices(HostBuilderContext host, IServiceCollection services)
  {
    Title("Configure Services");

    var config = host.Configuration;
    var strong = StrongConfig.Instance(config);

    PrintConfig(config);
    PrintConfig(strong);

    services.Configure<PositionOptions>(host.Configuration.GetSection(PositionOptions.SectionName));
    services.AddSingleton<IHostedService, App5Service>();
    // services.AddDbContext<DbPgContext>();

    

    Title("Finished Startup Pipeline");
  }
}
