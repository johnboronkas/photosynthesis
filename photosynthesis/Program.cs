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

            var gameState = new GameState(new List<Player>()
            {
                new Player(Team.Orange),
                new Player(Team.Blue),
                new Player(Team.Green),
                new Player(Team.Yellow),
            }, board, scoreTokens, gameFile);

            // TODO After each player places both starting trees, need to call gameState.CollectLightPoints().
            // TODO Need specific setup function that does above and resets the turn order (dosen't use 'pass').
            
            while (true)
            {
                while (!interpreter.DoAction(gameState, GetUserInput()));
            }
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
