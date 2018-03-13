namespace photosynthesis.interpreter.commands
{
    public interface Command
    {
        /// <summary>
        /// Returns a GameMode containing the conditions of the command's useage.
        /// </summary>
        GameMode GetUseability();

        /// <summary>
        /// Tests to see if the command is legal, but doesn't carry it out if it is.
        /// </summary>
        CommandResponse CanPerform(GameState gameState, params string[] parameters);

        /// <summary>
        /// Throws InvalidCommandException if the command provided is invalid or illegal.
        /// </summary>
        CommandResponse Perform(GameState gameState, params string[] parameters);
    }
}
