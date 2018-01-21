using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using photosynthesis.state;

namespace photosynthesis.interpreter.commands
{
    public class WriteGameFile : Command
    {
        public void Perform(GameFile gameFile, Board board, Player player, params string[] parameters)
        {
            gameFile.WriteToDisk(Environment.CurrentDirectory + "gamefile.txt");
        }
    }
}
