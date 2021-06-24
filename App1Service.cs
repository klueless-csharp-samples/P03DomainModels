using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class App1Service : IHostedService
{
  private readonly ILogger logger;

  public App1Service(
      ILogger<App1Service> logger,
      IHostApplicationLifetime appLifetime)
  {
    if (logger == null)
    {
      throw new ArgumentNullException(nameof(logger));
    }

    if (appLifetime == null)
    {
      throw new ArgumentNullException(nameof(appLifetime));
    }

    this.logger = logger;

    appLifetime.ApplicationStarted.Register(OnStarted);
    appLifetime.ApplicationStopping.Register(OnStopping);
    appLifetime.ApplicationStopped.Register(OnStopped);
  }

  public Task StartAsync(CancellationToken cancellationToken)
  {
    this.logger.LogInformation("1. StartAsync has been called.");

    return Task.CompletedTask;
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    this.logger.LogInformation("4. StopAsync has been called.");

    return Task.CompletedTask;
  }

  private void OnStarted()
  {
    this.logger.LogInformation("2. OnStarted has been called.");
  }

  private void OnStopping()
  {
    this.logger.LogInformation("3. OnStopping has been called.");
  }

  private void OnStopped()
  {
    this.logger.LogInformation("5. OnStopped has been called.");
  }
}
