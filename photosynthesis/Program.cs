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
            var players = new List<Player>()
            {
                new Player(Team.Orange),
                new Player(Team.Blue),
                new Player(Team.Green),
                new Player(Team.Yellow),
            };

            var board = new Board();
            var gameFile = new GameFile();
            var interpreter = new CommandInterpreter();
            interpreter.DoAction(gameFile, board, new Player(Team.None), players, new List<string>() { "help" });

            var currentPlayerNum = 0;
            while (true)
            {
                Console.WriteLine(board);
                while (!interpreter.DoAction(gameFile, board, players[currentPlayerNum], players, GetUserInput()));
                currentPlayerNum = ++currentPlayerNum % players.Count;
            }

            Console.ReadLine();
        }

        static List<string> GetUserInput()
        {
            Console.Write("> ");
            var input = Console.ReadLine();
            return input.Split(' ').ToList();
        }
    }
}
