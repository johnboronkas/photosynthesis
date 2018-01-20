using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photosynthesis
{
    public class GameFile
    {
        private StringBuilder Moves;

        public GameFile()
        {
            Moves = new StringBuilder();
        }

        public void AddMove(string move)
        {
            Moves.AppendLine(move);
        }

        public void WriteToDisk(string path)
        {
            File.WriteAllText(path, Moves.ToString());
        }
    }
}
