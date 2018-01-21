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
        public void Perform(GameFile gameFile, Board board, Player player, List<Player> players, params string[] parameters)
        {
            var path = Environment.CurrentDirectory + "\\gamefile.txt";
            gameFile.WriteToDisk(path);
            Console.WriteLine(string.Format("Game file written to: `{0}`.", path));
        }
    }
}
