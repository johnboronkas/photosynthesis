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
        public void Perform(GameFile gameFile, Board board, PlayerTracker playerTracker, params string[] parameters)
        {
            Space space;
            board.State.TryGetValue(CommandInterpreter.ParamsToHex(parameters.Skip(1).Take(3).ToList()), out space);
            
            if (space.ScoreValue <= 1)
            {
                space.Set(playerTracker.CurrentPlayer.Team, Token.SmallTree);
            }
            else
            {
                throw new InvalidCommandException("Starting trees may only be placed on spaces that have a score value of 1 or less.");
            }
        }
    }
}
