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

            var gameMode = GameMode.Config | GameMode.Advanced | GameMode.HumanFriendly;
            var gameState = new GameState(gameMode, board, scoreTokens, gameFile);

            if (gameState.GameMode.IsSet(GameMode.HumanFriendly)) Console.WriteLine("\nBegin configuration.");
            while (gameState.GameMode.IsSet(GameMode.Config))
            {
                while (interpreter.DoAction(gameState, GetUserInput(gameState.GameMode)) == CommandState.Failure);
                if (gameState.GameMode.IsSet(GameMode.HumanFriendly)) Console.WriteLine("GameMode is now " + gameState.GameMode);
            }

            if (gameState.GameMode.IsSet(GameMode.HumanFriendly)) Console.WriteLine("Playing with gamemode set to " + gameState.GameMode);

            if (gameState.GameMode.IsSet(GameMode.HumanFriendly)) Console.WriteLine("\nBegin game init.");
            DoInitialSetup(gameState, interpreter);

            if (gameState.GameMode.IsSet(GameMode.HumanFriendly)) Console.WriteLine("\nThe game begins.");
            while (true)
            {
                if (gameState.GameMode.IsSet(GameMode.HumanFriendly)) Console.WriteLine(string.Format("\nIt's {0}'s turn.", gameState.CurrentPlayer.Team));
                while (interpreter.DoAction(gameState, GetUserInput(gameState.GameMode)) == CommandState.Failure);
            }
        }

        static void DoInitialSetup(GameState gameState, CommandInterpreter interpreter)
        {
            int numPlayers = gameState.Players.Count;
            for (int i = 0; i < numPlayers * 2; i++)
            {
                gameState.SetCurrentPlayer(i % numPlayers);
                if (gameState.GameMode.IsSet(GameMode.HumanFriendly)) Console.WriteLine(string.Format("\nIt's {0}'s turn.", gameState.CurrentPlayer.Team));
                while (interpreter.DoAction(gameState, GetUserInput(gameState.GameMode)) != CommandState.GameStateUpdated);
            }

            gameState.CollectLightPoints();
            gameState.SetCurrentPlayer(0);
            gameState.SetGameMode(GameMode.Init, false);
            gameState.SetGameMode(GameMode.Playing, true);
        }

        static List<string> GetUserInput(GameMode gameMode)
        {
            var prompt = "$ ";
            if (gameMode.IsSet(GameMode.Debug)) prompt = "# ";

            Console.Write(prompt);
            var input = Console.ReadLine();
            return input.Split(' ').ToList();
        }
    }
}
