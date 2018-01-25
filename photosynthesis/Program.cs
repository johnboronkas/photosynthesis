using photosynthesis.interpreter;
using photosynthesis.state;
using System;
using System.Collections.Generic;
using System.Linq;

namespace photosynthesis
{
    /// <summary>
    /// Start with the board facing you with the sun start marker in the top right.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            var scoreTokens = new ScoreTokens();
            var gameFile = new GameFile();
            var interpreter = new CommandInterpreter();

            // TODO Add gamesetup commands.

            var gameState = new GameState(new List<Player>()
            {
                new Player(Team.Orange),
                new Player(Team.Blue),
                new Player(Team.Green),
                new Player(Team.Yellow),
            }, board, scoreTokens, gameFile);

            if (GameState.HumanFriendlyConsole) Console.WriteLine("\nBegin game setup.");
            DoInitialSetup(gameState, interpreter);

            if (GameState.HumanFriendlyConsole) Console.WriteLine("\nThe game begins.");
            while (true)
            {
                if (GameState.HumanFriendlyConsole) Console.WriteLine(string.Format("\nIt's {0}'s turn.", gameState.CurrentPlayer.Team));
                while (interpreter.DoAction(gameState, GetUserInput()) == CommandState.Failure);
            }
        }

        static void DoInitialSetup(GameState gameState, CommandInterpreter interpreter)
        {
            int numPlayers = gameState.Players.Count;
            for (int i = 0; i < numPlayers * 2; i++)
            {
                gameState.SetCurrentPlayer(i % numPlayers);
                if (GameState.HumanFriendlyConsole) Console.WriteLine(string.Format("\nIt's {0}'s turn.", gameState.CurrentPlayer.Team));
                while (interpreter.DoAction(gameState, GetUserInput()) != CommandState.GameStateUpdated);
            }

            gameState.CollectLightPoints();
            gameState.SetCurrentPlayer(0);
            gameState.InitMode = false;
        }

        static List<string> GetUserInput()
        {
            var prompt = "$ ";
            if (GameState.DebugMode) prompt = "# ";

            Console.Write(prompt);
            var input = Console.ReadLine();
            return input.Split(' ').ToList();
        }
    }
}
