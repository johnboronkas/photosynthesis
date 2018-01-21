using System.IO;
using System.Text;

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
