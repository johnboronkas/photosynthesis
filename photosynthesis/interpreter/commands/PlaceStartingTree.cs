using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using photosynthesis.state;

namespace photosynthesis.interpreter.commands
{
    public class PlaceStartingTree : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            Space space;
            gameState.Board.State.TryGetValue(CommandInterpreter.ParamsToHex(parameters.Skip(1).Take(3).ToList()), out space);
            
            if (space.ScoreValue <= 1)
            {
                space.Set(gameState.CurrentPlayer.Team, Token.SmallTree);
                return new CommandResponse(true);
            }
            else
            {
                return new CommandResponse(false, "Starting trees may only be placed on spaces that have a score value of 1 or less.");
            }
        }
    }
}
