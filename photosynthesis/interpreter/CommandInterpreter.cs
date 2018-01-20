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
        public bool DoAction(List<string> action, GameFile gameFile)
        {
            try
            {
                var type = Type.GetType("photosynthesis.interpreter.commands." + action.First(), true, true);
                Command instance = (Command)Activator.CreateInstance(type);
                instance.Perform(action.ToArray());
                gameFile.AddMove(action.Aggregate((s1, s2) => { return s1 + " " + s2; }));
                return true;
            }
            catch (Exception e)
            {
                if (e is ArgumentNullException || e is TargetInvocationException ||
                    e is TypeLoadException || e is ArgumentException || e is FileNotFoundException ||
                    e is FileLoadException || e is BadImageFormatException || e is NotSupportedException ||
                    e is TargetInvocationException || e is MethodAccessException || e is MemberAccessException ||
                    e is InvalidComObjectException || e is MissingMethodException || e is COMException || e is InvalidOperationException)
                {

                    return false;
                }

                throw;
            }
        }
    }
}
