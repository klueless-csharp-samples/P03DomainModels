using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using P03DomainModels.Startup;

// Simple Service configured via Dependency Injection with Configuration Loaded
public static class AppFooBar
{
  internal static Task Go(string[] args)
  {
    return CreateHostBuilder(args).Build().RunAsync();
  }

  internal static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
          .UseStartupPipeline<AppFooBarStartup>(args);
}
