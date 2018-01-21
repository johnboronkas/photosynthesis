using photosynthesis.state;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photosynthesis.interpreter.commands
{
    public class Upgrade : Command
    {
        public void Perform(GameFile gameFile, Board board, Player player, params string[] parameters)
        {
            Space space;
            board.State.TryGetValue(CommandInterpreter.ParamsToHex(parameters.Skip(1).Take(3).ToList()), out space);

            space.Set(player.Team, Token.SmallTree);
        }
    }
}
