using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using photosynthesis.state;

namespace photosynthesis.interpreter.commands
{
    public class Pass : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            gameState.EndTurn();
            return new CommandResponse(true);
        }
    }
}
