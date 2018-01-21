using photosynthesis.interpreter;
using photosynthesis.state;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var gameFile = new GameFile();
            var interpreter = new CommandInterpreter();

            var gameState = new GameState(new List<Player>()
            {
                new Player(Team.Orange),
                new Player(Team.Blue),
                new Player(Team.Green),
                new Player(Team.Yellow),
            }, board, gameFile);

            // TODO After each player places both starting trees, need to call gameState.CollectLightPoints().
            
            while (true)
            {
                while (!interpreter.DoAction(gameState, GetUserInput()));
            }
        }

        static List<string> GetUserInput()
        {
            Console.Write("> ");
            var input = Console.ReadLine();
            return input.Split(' ').ToList();
        }
    }
}
