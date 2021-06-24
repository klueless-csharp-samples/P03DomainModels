namespace P03DomainModels
{
  using System;
  using System.Linq;
  using BetterConsoleTables;

  public static class PrintWithBetterConsoleTables
  {
    public static void Print(Competion competion)
    {
      if (competion == null)
      {
        throw new ArgumentNullException(nameof(competion));
      }

      var printPlayers = new Table("Player");
      var printWinners = new Table("Comp ID", "Game ID", "Winner");
      var printCompetitors = new Table("Game ID", "Name", "Score", "Winner");

      // printWinners.Config = TableConfiguration.Markdown();
      printPlayers.Config = TableConfiguration.Unicode();
      printWinners.Config = TableConfiguration.Unicode();
      printCompetitors.Config = TableConfiguration.Unicode();

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

      var tables = new ConsoleTables(printPlayers, printWinners, printCompetitors);

      Console.Write(tables.ToString());
    }
  }
}
