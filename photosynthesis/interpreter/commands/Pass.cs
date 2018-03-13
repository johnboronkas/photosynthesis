namespace photosynthesis.interpreter.commands
{
    public class Pass : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Playing;
        }

        public CommandResponse CanPerform(GameState gameState, params string[] parameters)
        {
            return new CommandResponse(CommandState.Successful);
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            gameState.EndTurn();
            return new CommandResponse(CommandState.GameStateUpdated);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "", "End your turn and advance the game.");
        }
    }
}
