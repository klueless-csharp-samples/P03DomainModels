namespace P03DomainModels.Startup
{
  using Microsoft.Extensions.Hosting;

  public static class StartupPipelineExtensions
  {
    public static IHostBuilder UseStartupPipeline<TStartup>(this IHostBuilder hostBuilder)
      where TStartup : IStartup, new() =>
            hostBuilder.UseStartupPipeline<TStartup>(args: null);

    public static IHostBuilder UseStartupPipeline<TStartup>(this IHostBuilder hostBuilder, string[] args)
      where TStartup : IStartup, new()
    {
      var startup = new TStartup() { Args = args };

      // 1. Fire Host Configuration
      var configureHost = startup as IStartupConfigureHostConfiguration;
      if (configureHost != null)
      {
        hostBuilder.ConfigureHostConfiguration(configureHost.ConfigureHostConfiguration);
      }

      // 2. Fire App Configuration
      var configureApp = startup as IStartupConfigureAppConfiguration;
      if (configureApp != null)
      {
        hostBuilder.ConfigureAppConfiguration(configureApp.ConfigureAppConfiguration);
      }

      // 3. Fire ConfigureLogging
      var configureLogging = startup as IStartupConfigureLogging;
      if (configureLogging != null)
      {
        hostBuilder.ConfigureLogging(configureLogging.ConfigureLogging);
      }

      // 4. Configure Services (Dependency Injection)
      var configureServices = startup as IStartupConfigureServices;
      if (configureServices != null)
      {
        hostBuilder.ConfigureServices(configureServices.ConfigureServices);
      }

      return hostBuilder;
    }
  }
}
