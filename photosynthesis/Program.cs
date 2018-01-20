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
            var gameFile = new GameFile();
            var interpreter = new CommandInterpreter();

            var board = new Board();

            while (true)
            {
                Console.WriteLine(board);
                while (!interpreter.DoAction(GetUserInput(), gameFile));
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
