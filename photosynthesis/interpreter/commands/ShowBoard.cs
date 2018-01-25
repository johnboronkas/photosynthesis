using System;

namespace photosynthesis.interpreter.commands
{
    public class ShowBoard : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            Console.WriteLine(gameState.Board.SpacesHumanReadable());
            return new CommandResponse(CommandState.Successful);
        }
    }
}
