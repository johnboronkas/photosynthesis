namespace photosynthesis.interpreter.commands
{
    public class Pass : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            gameState.EndTurn();
            return new CommandResponse(true);
        }
    }
}
