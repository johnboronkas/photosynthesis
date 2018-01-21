using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using photosynthesis.interpreter.commands;
using photosynthesis.state;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;

namespace photosynthesis.interpreter
{
    public class CommandInterpreter
    {
        public bool DoAction(GameFile gameFile, Board board, Player player, List<Player> players, List<string> action)
        {
            try
            {
                var type = Type.GetType("photosynthesis.interpreter.commands." + action.First(), true, true);
                Command instance = (Command)Activator.CreateInstance(type);
                instance.Perform(gameFile, board, player, players, action.ToArray());
                gameFile.AddMove((int)player.Team + " " + action.Aggregate((s1, s2) => { return s1 + " " + s2; }));
                return true;
            }
            catch (Exception e)
            {
                if (e is ArgumentNullException || e is TargetInvocationException ||
                    e is TypeLoadException || e is ArgumentException || e is FileNotFoundException ||
                    e is FileLoadException || e is BadImageFormatException || e is NotSupportedException ||
                    e is TargetInvocationException || e is MethodAccessException || e is MemberAccessException ||
                    e is InvalidComObjectException || e is MissingMethodException || e is COMException || e is InvalidOperationException ||
                    e is InvalidCommandException)
                {
                    Console.WriteLine(e);
                    return false;
                }

                throw;
            }
        }

        internal static Hex ParamsToHex(List<string> parameters)
        {
            return new Hex(int.Parse(parameters[0]), int.Parse(parameters[1]), int.Parse(parameters[2]));
        }
    }
}
