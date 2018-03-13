using System;
using System.Linq;
using System.Text;

namespace photosynthesis.interpreter.commands
{
    public class Help : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Config | GameMode.Init | GameMode.Playing;
        }

        public CommandResponse CanPerform(GameState gameState, params string[] parameters)
        {
            return new CommandResponse(CommandState.Successful);
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            StringBuilder help = new StringBuilder();

            foreach (Type type in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                 .Where(type => type.GetInterfaces().Contains(typeof(Command))))
            {
                Command command = (Command)Activator.CreateInstance(type);

                // Check for Debug.
                if (command.GetUseability().IsSet(GameMode.Debug) &&
                   !gameState.GameMode.IsSet(GameMode.Debug))
                {
                    continue;
                }

                // Check if we are currently in the correct game phase.
                if (!command.GetUseability().IsSamePhase(gameState.GameMode))
                {
                    continue;
                }

                help.AppendFormat("{0}{1}{2}", command.ToString(), Environment.NewLine, Environment.NewLine);
            }

            Console.WriteLine(help.ToString());
            return new CommandResponse(CommandState.Successful);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "", "Prints this help menu.");
        }
    }
}
