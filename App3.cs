using System;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Configuration;
using P03DomainModels.Options;

// Simple configuration loader
public static class App3
{
  internal static void Go(string[] args)
  {
    var config = GetConfig(args);

    var configured = StrongConfig.Instance(config);

    PrintConfig(config, configured);
  }

  private static IConfiguration GetConfig(string[] args)
  {
    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    // dotnet run Position:Title=Xxxxxx Position:Name=Yyyyyy
    return new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
      .AddJsonFile($"appSettings.{env}.json", optional: true)
      .AddCommandLine(args)
      // .AddEnvironmentVariables()
      .Build();
  }

  private static void PrintConfig(IConfiguration config, StrongConfig configured)
  {
    var po = configured.Position;

    var section = config.GetSection("ConnectionStrings");

    Kv("MsSql", section.GetValue<string>("MsSql"));
    Kv("PgSql", section.GetValue<string>("PgSql"));

    Kv("ConnectionString", config["ConnectionString"]);
    Kv("Title", po.Title);
    Kv("Name", po.Name);
    Kv("defaultLogLevel", config["Logging:LogLevel:Default"]);
  }

  private static void W(string message)
  {
    Console.WriteLine(message);
  }

  private static void Line()
  {
    Console.WriteLine("------------------------------------------------");
  }

  private static void Kv(string key, string value)
  {
    Console.WriteLine("{0,-30}: {1}", key, value);
  }

  private static void Kv(string key, int value)
  {
    Kv(key, value.ToString(CultureInfo.InvariantCulture));
  }
}
