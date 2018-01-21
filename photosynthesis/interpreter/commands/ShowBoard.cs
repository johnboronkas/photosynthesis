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
        public void Perform(GameFile gameFile, Board board, PlayerTracker playerTracker, params string[] parameters)
        {
            Console.WriteLine(board.SpacesHumanReadable());
        }
    }
}
