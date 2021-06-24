using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using P03DomainModels.Context;
using P03DomainModels.Options;

public class App5Service : IHostedService, IDisposable
{
  private readonly ILogger logger;
  private readonly IOptions<PositionOptions> positionOptions;
  private Timer timer;

  public App5Service(
      ILogger<App2Service> logger,
      IOptions<PositionOptions> positionOptions,
      DomainContext ctx)
  {
    this.logger = logger;
    this.positionOptions = positionOptions;
  }

  public Task StartAsync(CancellationToken cancellationToken)
  {
    this.logger.LogInformation("Starting");

    this.timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

    return Task.CompletedTask;
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    this.logger.LogInformation("Stopping.");

    this.timer?.Change(Timeout.Infinite, 0);

    return Task.CompletedTask;
  }

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (disposing)
    {
      this.timer?.Dispose();
    }
  }

  private void DoWork(object state)
  {
    this.logger.LogInformation($"Background work with text: {positionOptions.Value.Title}");
    this.logger.LogDebug("Doing");
  }
}
