using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class App2Service : IHostedService
{
  private readonly ILogger logger;

  public App2Service(
      ILogger<App2Service> logger,
      IHostApplicationLifetime appLifetime)
  {
    this.logger = logger;
  }

  public Task StartAsync(CancellationToken cancellationToken)
  {
    this.logger.LogInformation("Start App2 Service");

    return Task.CompletedTask;
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    return Task.CompletedTask;
  }
}
