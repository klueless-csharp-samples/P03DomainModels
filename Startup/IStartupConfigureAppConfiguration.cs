namespace P03DomainModels
{
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.Hosting;

  public interface IStartupConfigureAppConfiguration : IStartup
  {
    void ConfigureAppConfiguration(HostBuilderContext host, IConfigurationBuilder configBuilder);
  }
}
