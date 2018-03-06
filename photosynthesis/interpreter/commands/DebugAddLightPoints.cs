using photosynthesis.state;

namespace photosynthesis.interpreter.commands
{
    public class DebugAddLightPoints : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Debug | GameMode.Playing;
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            gameState.Players.ForEach((player) =>
            {
                player.AddLightPoints(Player.MaxLightPoints);
            });

            return new CommandResponse(CommandState.GameStateUpdated);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "", "Maxes out every player's light points.");
        }
    }
}
