namespace P03DomainModels.Options
{
  public class ConnectionStringsOptions
  {
    public const string SectionName = "ConnectionStrings";

    public string MsSql { get; set; }
    public string PgSql { get; set; }
  }
}
