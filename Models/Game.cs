namespace P03DomainModels
{
  using System.Collections.Generic;
  using System.Linq;

  public class Game
  {
    public Game()
    {
    }

    public int Id { get; set; }

    public List<Competitor> Competitors { get; } = new List<Competitor>();

    public bool IsAtCapacity
    {
      // It is possible to go over capacity, but that only happens if there is a spare player at the end.
      get
      {
        return Competitors.Count == 2;
      }
    }

    public Competitor Winner
    {
      get
      {
        return this.Competitors.OrderBy(c => c.Score).Last();
      }
    }

    public void Add(Player player)
    {
      Competitors.Add(new Competitor { Player = player, Game = this });
    }

    public void Commence()
    {
      // Each competitor rolls the dice
      Competitors.ForEach(c => c.Roll());
    }
  }
}
