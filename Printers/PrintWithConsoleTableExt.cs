namespace P03DomainModels
{
  using System;
  using System.Linq;
  using ConsoleTableExt;

  public static class PrintWithConsoleTableExt
  {
    public static void Print(Competion competion)
    {
      if (competion == null)
      {
        throw new ArgumentNullException(nameof(competion));
      }

      // var printPlayers = new ConsoleTable("Player");
      // var printWinners = new ConsoleTable("Comp ID", "Game ID", "Winner");
      // var printCompetitors = new ConsoleTable("Game ID", "Name", "Score", "Winner");

      var players = competion
        .Players
        .Select(p => new { PlayerName = p.FullName })
        .ToList();
      // ConsoleTableBuilder.From(players).WithFormat(ConsoleTableBuilderFormat.MarkDown).ExportAndWriteLine();
      ConsoleTableBuilder
        .From(players)
        .WithTitle("PLAYERS", ConsoleColor.Red)
        .WithFormat(ConsoleTableBuilderFormat.MarkDown)
        .ExportAndWriteLine();

      var games = competion
        .Games
        .Select(g => new
        {
          CompetitionId = competion.Id,
          GameId = g.Id,
          Winner = g.Winner.Player.FullName
        })
        .ToList();

      ConsoleTableBuilder
        .From(games)
        .WithTitle("Games", ConsoleColor.Red)
        .WithFormat(ConsoleTableBuilderFormat.MarkDown)
        .ExportAndWriteLine();

      var gameCompetitors = competion
        .Games
        .Select(game => new
        {
          GameId = game.Id,
          Winner = game.Winner.Player.FullName,
          Competitors = string.Join(
            " | ",
            game.Competitors.Select(competitor =>
              $"{competitor.Player.FullName,-10} {(competitor.Id == game.Winner.Id ? "WIN" : string.Empty),-3} ({competitor.Score,-1})"))
        }).ToList();

      // var gameCompetitors = competion
      //   .Games
      //   .Select(game => new {
      //     GameId = game.Id,
      //     Winner = game.Winner.Player.FullName,
      //     Competitors = game.Competitors.Select(competitor => new {
      //       Score = competitor.Score,
      //       Message = competitor.Id == game.Winner.Id ? "Winner" : string.Empty
      //     })
      //   }).ToList();

      ConsoleTableBuilder
        .From(gameCompetitors)
        .WithTitle("Game Competitors", ConsoleColor.Red)
        .WithFormat(ConsoleTableBuilderFormat.MarkDown)
        .ExportAndWriteLine();
    }
  }
}
