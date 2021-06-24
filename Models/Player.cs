namespace P03DomainModels
{
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;

  public class Player
  {
    public Player()
    {
    }

    public int Id { get; set; }

    [Required]
    public string FullName { get; set; }

    public List<Competitor> CompetedGames { get; } = new List<Competitor>();
  }
}
