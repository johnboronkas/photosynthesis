using System.Linq;

namespace photosynthesis.interpreter.commands
{
    public class HumanFriendlyMode : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Config;
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            bool? useHumanFriendlyModeMaybe = CommandInterpreter.ParamsToOnOff(parameters.ToList());
            if (!useHumanFriendlyModeMaybe.HasValue) return new CommandResponse(CommandState.Failure, "Argument must be on or off.");

            gameState.SetGameMode(GameMode.HumanFriendly, useHumanFriendlyModeMaybe.Value);
            return new CommandResponse(CommandState.Successful);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "on/off", "Sets if the game should include human friendly console printouts.");
        }
    }
}