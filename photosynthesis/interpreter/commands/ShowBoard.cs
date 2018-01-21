using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using photosynthesis.state;

namespace photosynthesis.interpreter.commands
{
    public class ShowBoard : Command
    {
        public void Perform(GameState gameState, params string[] parameters)
        {
            Console.WriteLine(gameState.Board.SpacesHumanReadable());
        }
    }
}
