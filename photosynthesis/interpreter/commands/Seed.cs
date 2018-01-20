using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photosynthesis.interpreter.commands
{
    public class Seed : Command
    {
        public void Perform(params string[] parameters)
        {
            Console.Write("Seeding: ");
            for (int i = 0; i < parameters.Count(); i++)
            {
                Console.Write(parameters[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
