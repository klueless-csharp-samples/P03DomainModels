namespace P03DomainModels
{
  using System;
  using System.Globalization;
  using System.Linq;
  using System.Threading.Tasks;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using P03DomainModels.Context;
  using P03DomainModels.Options;

  public static class Program
  {
    // public static async Task Main(string[] args)
    // {
    //   await App5.Go(args);
    // }

    public static void Main(string[] args)
    {
      App1.Go(args);
      // App2.Go(args);
      // App3.Go(args);
      // App4.Go(args);
      // AppFooBar.Go(args);
      // AppX(args);
    }

    public static void AppX(string[] args)
    {
      var players = new[]
      {
        "David",
        "Lisa",
        "James",
        "Reynaldo",
        "Frederick",
        "Jenny",
        "Paul",
        "Laura",
        "Steve",
        "Rueben",
        "Robert",
        "Sandra",
        "Allison",
      };

      var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

      Kv("Environment Name", environmentName);

      // var services = ConfiguredServices(config);

      using (var context = new DbMsContext())
      {
        // Execute(context, players);
        Print(context);
      }

      // using (var context = new DbPgContext())
      // {
      //   Execute(context, players);
      //   Print(context);
      // }
    }

    // ToDo: Read Dependency Injection

    private static void Execute(DomainContext context, string[] playerNames)
    {
      Console.WriteLine("Create Context");

      var competion = new Competion();

      context.Competions.Add(competion);
      // context.Players.AddIfNotExist((p) => p.Name == "david" )

      competion.RegisterPlayers(playerNames);
      competion.GenerateGames();
      competion.Start();

      context.SaveChanges();

      PrintCompetition(competion);
    }

    private static void Print(DomainContext context)
    {
      var queryCompetion = context.Competions
        .Include(c => c.Players)
        .Include(c => c.Games)
          .ThenInclude(c => c.Competitors)
        .OrderBy(c => c.Id)
        .Last();

      // PrintWithBetterConsoleTables.Print(queryCompetion);
      // PrintWithConsoleTables.Print(queryCompetion);
      PrintWithConsoleTableExt.Print(queryCompetion);

      // PrintCompetition2(context);
    }

    private static void PrintCompetition(Competion competion)
    {
      Kv("Competition ID", competion.Id);

      PrintPlayers(competion);
      PrintGames(competion);
    }

    private static void PrintPlayers(Competion competion)
    {
      Kv("# of players", competion.Players.Count);

      var playerNames = competion.Players.Select(p => p.FullName);
      Kv("Player names", string.Join(", ", playerNames));
    }

    private static void PrintGames(Competion competion)
    {
      foreach (var game in competion.Games)
      {
        Kv("Game ID", game.Id);
        Kv("# of competitors in game", game.Competitors.Count);

        // var playerNames = game.Competitors.Select(c => c.Player.FullName);
        // Kv("Competitor names in game", string.Join(", ", playerNames));

        // var playerResults = game.Competitors.Select(c => string.Format("{0}: ({1})", c.Player.FullName, c.Score));
        var playerResults = game.Competitors.Select(c => $"{c.Player.FullName}: ({c.Score})");

        Kv("Competitor results", string.Join(", ", playerResults));
        Kv("Winner", game.Winner.Player.FullName);
        Line();
      }
    }

    private static object ConfiguredServices(IConfiguration config, IServiceCollection services)
    {
      services.Configure<PositionOptions>(config.GetSection(PositionOptions.SectionName));

      return null;
    }
    
    private static void W(string message)
    {
      Console.WriteLine(message);
    }

    private static void Line()
    {
      Console.WriteLine("------------------------------------------------");
    }

    private static void Kv(string key, string value)
    {
      Console.WriteLine("{0,-30}: {1}", key, value);
    }

    private static void Kv(string key, int value)
    {
      Kv(key, value.ToString(CultureInfo.InvariantCulture));
    }

    private static void RegisterPlayers(Competion competion)
    {
      Console.WriteLine("Register Players");

      competion.AddPlayer("David");
      competion.AddPlayer("Lisa");
      competion.AddPlayer("James");
      competion.AddPlayer("Reynaldo");
      competion.AddPlayer("Frederick");
      competion.AddPlayer("Jenny");
      competion.AddPlayer("Paul");
      competion.AddPlayer("Laura");
      competion.AddPlayer("Steve");
      competion.AddPlayer("Rueben");
      competion.AddPlayer("Robert");
      competion.AddPlayer("Sandra");
      competion.AddPlayer("Allison");
    }
  }
}
