namespace photosynthesis.interpreter.commands
{
    public interface Command
    {
        /// <summary>
        /// Throws InvalidCommandException if the command provided is invalid or illegal.
        /// </summary>
        CommandResponse Perform(GameState gameState, params string[] parameters);
    }
}
