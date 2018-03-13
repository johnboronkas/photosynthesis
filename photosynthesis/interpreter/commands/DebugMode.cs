using System.Linq;

namespace photosynthesis.interpreter.commands
{
    public class DebugMode : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Config;
        }

        public CommandResponse CanPerform(GameState gameState, params string[] parameters)
        {
            return new CommandResponse(CommandState.Successful);
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            bool? useDebugModeMaybe = CommandInterpreter.ParamsToOnOff(parameters.ToList());
            if (!useDebugModeMaybe.HasValue) return new CommandResponse(CommandState.Failure, "Argument must be on or off.");

            gameState.SetGameMode(GameMode.Debug, useDebugModeMaybe.Value);
            return new CommandResponse(CommandState.Successful);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "on/off", "Sets if the game should be played with debug commands enabled.");
        }
    }
}