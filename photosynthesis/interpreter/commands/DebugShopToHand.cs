namespace photosynthesis.interpreter.commands
{
    public class DebugShopToHand : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            gameState.Players.ForEach((player) =>
            {
                player.Hand.AddRange(player.Shop);
            });

            return new CommandResponse(true);
        }
    }
}
