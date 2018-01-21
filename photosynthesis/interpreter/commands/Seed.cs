using photosynthesis.state;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photosynthesis.interpreter.commands
{
    public class Seed : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            // TODO Seed
            return new CommandResponse(false, "unimplemented");
        }
    }
}
