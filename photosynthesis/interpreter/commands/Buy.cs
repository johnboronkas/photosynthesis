namespace photosynthesis.interpreter.commands
{
    public class Buy : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            // TODO Buy
            return new CommandResponse(false, "unimplemented");
        }
    }
}
