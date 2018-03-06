using System;

namespace photosynthesis.interpreter.commands
{
    public class ShowBoard : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Init | GameMode.Playing;
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            Console.WriteLine(gameState.Board.SpacesHumanReadable());
            return new CommandResponse(CommandState.Successful);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "", "Prints TeamNum and Token, where '--' is none.");
        }
    }
}
