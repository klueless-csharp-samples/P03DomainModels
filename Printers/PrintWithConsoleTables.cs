namespace P03DomainModels
{
  using System;
  using System.Linq;
  using ConsoleTables;

  public static class PrintWithConsoleTables
  {
    public static void Print(Competion competion)
    {
      if (competion == null)
      {
        throw new ArgumentNullException(nameof(competion));
      }

      var printPlayers = new ConsoleTable("Player");
      var printWinners = new ConsoleTable("Comp ID", "Game ID", "Winner");
      var printCompetitors = new ConsoleTable("Game ID", "Name", "Score", "Winner");

      foreach (var name in competion.Players.Select(p => p.FullName))
      {
        printPlayers.AddRow(name);
      }

      foreach (var game in competion.Games)
      {
        printWinners.AddRow(competion.Id, game.Id, game.Winner.Player.FullName);

        foreach (var competitor in game.Competitors)
        {
          printCompetitors.AddRow(game.Id, competitor.Player.FullName, competitor.Score, competitor.Id == game.Winner.Id ? ":) - Winner" : ":(");
        }
      }

      printPlayers.Write(Format.Minimal);
      printWinners.Write(Format.Minimal);
      printCompetitors.Write(Format.Minimal);
    }
  }
}
