namespace photosynthesis.interpreter.commands
{
    public interface Command
    {
        /// <summary>
        /// Returns a GameMode containing the conditions of the command's useage.
        /// </summary>
        GameMode GetUseability();

        /// <summary>
        /// Throws InvalidCommandException if the command provided is invalid or illegal.
        /// </summary>
        CommandResponse Perform(GameState gameState, params string[] parameters);
    }
}
