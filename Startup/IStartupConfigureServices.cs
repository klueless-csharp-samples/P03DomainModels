namespace P03DomainModels
{
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;

  public interface IStartupConfigureServices : IStartup
  {
    void ConfigureServices(HostBuilderContext host, IServiceCollection services);
  }
}
