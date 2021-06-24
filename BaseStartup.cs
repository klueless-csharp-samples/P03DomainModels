using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using P03DomainModels;
using P03DomainModels.Options;

public class BaseStartup :
  IStartupConfigureHostConfiguration,
  IStartupConfigureAppConfiguration,
  IStartupConfigureLogging
{
  public string[] Args { get; set; }
  public void ConfigureHostConfiguration(IConfigurationBuilder config)
  {
    Title("Host Configuration");

    config
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
      .AddEnvironmentVariables();

    if (Args != null)
    {
      Title("Add command line arguments");
      config.AddCommandLine(Args);
    }
  }

  public void ConfigureAppConfiguration(HostBuilderContext host, IConfigurationBuilder config)
  {
    Title("App Configuration");

    var env = host.HostingEnvironment;

    if (env.IsDevelopment())
    {
      if (Assembly.Load(new AssemblyName(env.ApplicationName)) != null)
      {
        config.AddUserSecrets(Assembly.Load(new AssemblyName((string)env.ApplicationName)), optional: true);
      }
    }

    // // dnr --environment=Development
    // // export DOTNET_ENVIRONMENT="Development"; dnr
    Kv("Is Development", host.HostingEnvironment.IsDevelopment());
    Kv("Environment Name", host.HostingEnvironment.EnvironmentName);
  }

  public void ConfigureLogging(HostBuilderContext host, ILoggingBuilder logging)
  {
    Title("Configure Logging");

    logging.AddConfiguration(host.Configuration.GetSection("Logging"));
    // logging.AddConsole();
    // logging.AddDebug();
  }

  protected void PrintConfig(IConfiguration config)
  {
    Kv("ConnectionString", config["ConnectionString"]);
    Kv("defaultLogLevel", config["Logging:LogLevel:Default"]);
  }

  protected void PrintConfig(StrongConfig config)
  {
    var po = config.Position;
    var cs = config.ConnectionStrings;

    Kv("MsSql", cs.MsSql);
    Kv("PgSql", cs.PgSql);

    Kv("Title", po.Title);
    Kv("Name", po.Name);
  }

  protected void W(string message)
  {
    Console.WriteLine(message);
  }

  protected void Line()
  {
    Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
  }

  protected void Title(string message)
  {
    Line();
    Console.WriteLine(message);
    Line();
  }

  protected void Kv(string key, string value)
  {
    Console.WriteLine("{0,-25}: {1}", key, value);
  }

  protected void Kv(string key, int value)
  {
    Kv(key, value.ToString(CultureInfo.InvariantCulture));
  }

  protected void Kv(string key, bool value)
  {
    Kv(key, value.ToString(CultureInfo.InvariantCulture));
  }
}
