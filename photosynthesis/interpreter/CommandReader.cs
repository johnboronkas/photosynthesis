using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using photosynthesis.interpreter.commands;

namespace photosynthesis.interpreter
{
    public class CommandReader
    {
        public void DoAction(List<string> action)
        {
            var type = Type.GetType("photosynthesis.interpreter.commands." + action.First(), true, true);
            Command instance = (Command)Activator.CreateInstance(type);
            action.RemoveAt(0);
            instance.Perform(action.ToArray());
        }
    }
}
