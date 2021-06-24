namespace P03DomainModels
{
  using System;

  // Compeitors represent the many players on a game
  // Rule:
  // Usually 2 players, but if there is a leftover player then it can be 3 players
  public class Competitor
  {
    public Competitor()
    {
    }

    public int Id { get; set; }

    public int GameId { get; set; }

    public Game Game { get; set; }

    public int PlayerId { get; set; }

    public Player Player { get; set; }
    public int Score { get; set; }

    public void Roll()
    {
      Score = new Random().Next(1, 10);
    }
  }
}
