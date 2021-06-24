namespace P03DomainModels.Options
{
  using Microsoft.Extensions.Configuration;

  public class StrongConfig
  {
    public PositionOptions Position { get; set; }

    public ConnectionStringsOptions ConnectionStrings { get; set; }

    internal static StrongConfig Instance(IConfiguration config)
    {
      return new StrongConfig
      {
        Position = config.GetSection(PositionOptions.SectionName).Get<PositionOptions>(),
        ConnectionStrings = config.GetSection(ConnectionStringsOptions.SectionName).Get<ConnectionStringsOptions>()
      };
    }
  }
}
