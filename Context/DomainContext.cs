namespace P03DomainModels.Context
{
  using Microsoft.EntityFrameworkCore;

  public class DomainContext : DbContext
  {
    public DbSet<Competion> Competions { get; set; }
    public DbSet<Competitor> Competitors { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }
  }
}
