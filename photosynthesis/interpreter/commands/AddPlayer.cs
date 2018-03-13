using System;
using photosynthesis.state;

namespace photosynthesis.interpreter.commands
{
    public class AddPlayer : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Config;
        }

        public CommandResponse CanPerform(GameState gameState, params string[] parameters)
        {
            if (gameState.Players.Count >= GameState.MaxPlayers)
            {
                return new CommandResponse(CommandState.Failure, string.Format("Cannot add another player. Already at the max of {0} players.", GameState.MaxPlayers));
            }
            else
            {
                return new CommandResponse(CommandState.Successful);
            }
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            CommandResponse response = CanPerform(gameState, parameters);
            if (response.State == CommandState.Failure)
            {
                return response;
            }

            var newPlayer = new Player((Team)gameState.Players.Count + 1);
            gameState.AddPlayer(newPlayer);

            if (gameState.GameMode.IsSet(GameMode.HumanFriendly)) Console.WriteLine("{0} player added ({1}/{2} players in game).",
                newPlayer.Team, gameState.Players.Count, GameState.MaxPlayers);

            return new CommandResponse(CommandState.Successful);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "", string.Format("Adds a player to the game if there is still room to join ({0} max players).", GameState.MaxPlayers));
        }
    }
}