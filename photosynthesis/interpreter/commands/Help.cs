using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using photosynthesis.state;

namespace photosynthesis.interpreter.commands
{
    public class Help : Command
    {
        public void Perform(GameFile gameFile, Board board, Player player, params string[] parameters)
        {
            StringBuilder help = new StringBuilder();

            help.AppendLine("help");
            help.AppendLine("showhex");
            help.AppendLine("buy tokenID");
            help.AppendLine("seed srcP srcQ srcR dstP dstQ dstR");
            help.AppendLine("upgrade p q r");
            help.AppendLine("writegamefile");

            Console.WriteLine(help.ToString());
        }
    }
}
