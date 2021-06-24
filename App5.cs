using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using P03DomainModels.Options;

// Simple Service configured via Dependency Injection with Configuration Loaded
public static class App5
{
  internal static async Task Go(string[] args)
  {
    await CreateHostBuilder(args).RunConsoleAsync();
  }

  internal static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureHostConfiguration(config =>
          {
            config
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables()
              .AddCommandLine(args);
          })
        .ConfigureAppConfiguration((hostContext, config) =>
          {
            var env = hostContext.HostingEnvironment;

            if (env.IsDevelopment())
            {
              var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
              if (appAssembly != null)
              {
                config.AddUserSecrets(appAssembly, optional: true);
              }
            }

            // dnr --environment=Development
            // export DOTNET_ENVIRONMENT="Development"; dnr
            Kv("Is Development", hostContext.HostingEnvironment.IsDevelopment());
            Kv("Environment Name", hostContext.HostingEnvironment.EnvironmentName);
          })
        .ConfigureLogging((hostContext, logging) =>
          {
            logging.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
            // logging.AddConsole();
            // logging.AddDebug();
          })
        .ConfigureServices((hostContext, services) =>
          {
            // services.AddOptions();
            services.Configure<PositionOptions>(hostContext.Configuration.GetSection(PositionOptions.SectionName));

            // services.AddOptions();
            // var config = hostContext.Configuration;
            // var strong = StrongConfig.Instance(config);

            // Kv("Is Development", hostContext.HostingEnvironment.IsDevelopment());

            // PrintConfig(config, strong);
            // services.AddHostedService<App2Service>();
            services.AddSingleton<IHostedService, App5Service>();
          });

  private static void PrintConfig(IConfiguration config, StrongConfig configured)
  {
    var po = configured.Position;
    var cs = configured.ConnectionStrings;

    var section = config.GetSection("ConnectionStrings");

    // Kv("MsSql", section.GetValue<string>("MsSql"));
    // Kv("PgSql", section.GetValue<string>("PgSql"));
    Kv("MsSql", cs.MsSql);
    Kv("PgSql", cs.PgSql);

    Kv("ConnectionString", config["ConnectionString"]);
    Kv("defaultLogLevel", config["Logging:LogLevel:Default"]);

    Kv("Title", po.Title);
    Kv("Name", po.Name);
  }

  private static void Kv(string key, string value)
  {
    Console.WriteLine("{0,-30}: {1}", key, value);
  }

  private static void Kv(string key, int value)
  {
    Kv(key, value.ToString(CultureInfo.InvariantCulture));
  }

  private static void Kv(string key, bool value)
  {
    Kv(key, value.ToString(CultureInfo.InvariantCulture));
  }
}
