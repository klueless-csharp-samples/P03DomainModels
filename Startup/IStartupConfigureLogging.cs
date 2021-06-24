namespace P03DomainModels
{
  using Microsoft.Extensions.Hosting;
  using Microsoft.Extensions.Logging;

  public interface IStartupConfigureLogging : IStartup
  {
    void ConfigureLogging(HostBuilderContext host, ILoggingBuilder logging);
  }
}
