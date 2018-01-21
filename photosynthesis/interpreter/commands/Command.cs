using photosynthesis.state;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photosynthesis.interpreter.commands
{
    public interface Command
    {
        /// <summary>
        /// Throws InvalidCommandException if the command provided is invalid or illegal.
        /// </summary>
        void Perform(GameFile gameFile, Board board, Player player, List<Player> players, params string[] parameters);
    }
}
