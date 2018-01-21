using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photosynthesis.interpreter.commands
{
    public class Exit : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            Environment.Exit(0);
            return new CommandResponse(true);
        }
    }
}
