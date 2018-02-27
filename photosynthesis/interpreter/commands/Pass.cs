namespace photosynthesis.interpreter.commands
{
    public class Pass : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Playing;
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            gameState.EndTurn();
            return new CommandResponse(CommandState.GameStateUpdated);
        }
    }
}
