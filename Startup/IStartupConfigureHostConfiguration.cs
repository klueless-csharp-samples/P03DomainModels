namespace P03DomainModels
{
  using Microsoft.Extensions.Configuration;

  public interface IStartupConfigureHostConfiguration : IStartup
  {
    void ConfigureHostConfiguration(IConfigurationBuilder configBuilder);
  }
}
