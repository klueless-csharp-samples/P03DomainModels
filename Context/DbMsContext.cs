namespace P03DomainModels.Context
{
  using Microsoft.EntityFrameworkCore;

  public class DbMsContext : DomainContext
  {
    // Pasword: ProgAtPete2040

    public DbMsContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost,1433; Database=P03;User=sa; Password=hamword");
  }
}
