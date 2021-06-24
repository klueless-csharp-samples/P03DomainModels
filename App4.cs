using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using P03DomainModels.Services;
using static System.Console;

// Multiple scoped services configured via Dependency Injection
public static class App4
{
  internal static Task Go(string[] args)
  {
    using IHost host = CreateHostBuilder(args).Build();

    ExemplifyScoping(host.Services, "Scope 1");
    ExemplifyScoping(host.Services, "Scope 2");
    ExemplifyScoping(host.Services, "Scope 3");

    return host.RunAsync();
  }

  private static void ExemplifyScoping(IServiceProvider services, string scope)
  {
    using IServiceScope serviceScope = services.CreateScope();

    IServiceProvider provider = serviceScope.ServiceProvider;

    var logger = provider.GetRequiredService<OperationLogger>();

    logger.LogOperations($"{scope}-Call 1 .GetRequiredService<OperationLogger>()");

    WriteLine("...");

    logger = provider.GetRequiredService<OperationLogger>();
    logger.LogOperations($"{scope}-Call 2 .GetRequiredService<OperationLogger>()");

    WriteLine();
  }

  private static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
              .ConfigureServices((_, services) =>
                  services.AddTransient<ITransientOperation, DefaultOperation>()
                          .AddScoped<IScopedOperation, DefaultOperation>()
                          .AddSingleton<ISingletonOperation, DefaultOperation>()
                          .AddTransient<OperationLogger>());
}
