using photosynthesis.interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photosynthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new CommandReader();
            var input = GetUserInput();
            reader.DoAction(input);

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
