namespace P03DomainModels
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  // Misspelled, should be Competition
  public class Competion
  {
    public Competion()
    {
    }

    public int Id { get; set; }

    public List<Player> Players { get; } = new List<Player>();

    public List<Game> Games { get; } = new List<Game>();

    private IEnumerable<Player> RandomPlayers
    {
      get
      {
        var random = new Random();

        return Players.OrderBy(x => random.Next());
      }
    }

    public Player AddPlayer(string name)
    {
      var p = new Player { FullName = name };

      Players.Add(p);

      return p;
    }

    // public Competitor AddCompetitor(Player p)
    // {
    //   return null;
    // }

    public void RegisterPlayers(string[] playerNames)
    {
      if (playerNames == null)
      {
        throw new ArgumentNullException(nameof(playerNames));
      }

      Console.WriteLine("Register Players");

      foreach (var name in playerNames)
      {
        AddPlayer(name);
      }
    }

    public void GenerateGames()
    {
      int unassigned = this.Players.Count;

      Game game = null;

      foreach (var player in RandomPlayers)
      {
        if (game == null)
        {
          game = NewGame();
        }

        game.Add(player);

        if (--unassigned != 1 && game.IsAtCapacity)
        {
          // Resetting for a new Game occurs when the game is at capacity
          // Unless there is one person left, they join in the last game.
          game = null;
        }
      }
    }

    public void Start()
    {
      this.Games.ForEach(g => g.Commence());
    }

    public Game NewGame()
    {
      var game = new Game();

      this.Games.Add(game);

      return game;
    }
  }
}
