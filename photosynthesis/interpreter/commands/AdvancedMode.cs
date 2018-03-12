using System.Linq;

namespace photosynthesis.interpreter.commands
{
    public class AdvancedMode : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Config;
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            bool? useAdvancedModeMaybe = CommandInterpreter.ParamsToOnOff(parameters.ToList());
            if (!useAdvancedModeMaybe.HasValue) return new CommandResponse(CommandState.Failure, "Argument must be on or off.");

            gameState.SetGameMode(GameMode.Advanced, useAdvancedModeMaybe.Value);
            return new CommandResponse(CommandState.Successful);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "on/off", "Sets if the game should be played using the advanced rule set.");
        }
    }
}