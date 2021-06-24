namespace P03DomainModels.Services
{
  using System;
  using Microsoft.Extensions.Logging;

  public class FooService : IFooService
  {
    private readonly ILogger<FooService> logger;
    public FooService(ILoggerFactory loggerFactory)
    {
      this.logger = loggerFactory.CreateLogger<FooService>();
    }

    public void DoThing(int number)
    {
      this.logger.LogInformation($"Doing the thing {number}");
    }
  }
}
