using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Simple Service configured via Dependency Injection
public class App1
{
  internal static Task Go(string[] args)
  {
    Console.WriteLine(Environment.GetEnvironmentVariable("DOT_X"));

    return CreateHostBuilder(args).Build().RunAsync();
  }

  internal static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
            services.AddHostedService<App1Service>());
}
