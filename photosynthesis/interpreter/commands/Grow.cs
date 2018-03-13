using photosynthesis.state;
using System.Linq;

namespace photosynthesis.interpreter.commands
{
    public class Grow : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Playing;
        }

        public CommandResponse CanPerform(GameState gameState, params string[] parameters)
        {
            Player player = gameState.CurrentPlayer;

            Space space;
            if (!gameState.Board.State.TryGetValue(CommandInterpreter.ParamsToHex(parameters.Skip(1).Take(3).ToList()), out space))
            {
                return new CommandResponse(CommandState.Failure, "Invalid hex. Use 'ShowHex' to view cube coordinates.");
            }

            if (space.Team != player.Team) return new CommandResponse(CommandState.Failure, "Cannot upgrade unowned hex.");
            if (player.UsedSpaces.Contains(space)) return new CommandResponse(CommandState.Failure, "Cannot use the same hex more than once a turn.");

            if (gameState.GameMode.IsSet(GameMode.Advanced))
            {
                if (!space.IsLit) return new CommandResponse(CommandState.Failure, "Cannot use an unlit hex.");
            }

            Token currentToken = space.Token;
            Token nextToken = currentToken + 1;

            if (nextToken == Token.Score)
            {
                if (!player.CanAfford((int)nextToken)) return new CommandResponse(CommandState.Failure, "Insufficient light points.");
                return new CommandResponse(CommandState.Successful);
            }

            if (!player.Hand.Contains(nextToken)) return new CommandResponse(CommandState.Failure, "Upgraded token missing from hand. Must buy one from the shop first.");
            if (!player.CanAfford((int)nextToken)) return new CommandResponse(CommandState.Failure, "Insufficient light points.");

            return new CommandResponse(CommandState.Successful);
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            CommandResponse response = CanPerform(gameState, parameters);
            if (response.State == CommandState.Failure)
            {
                return response;
            }

            Player player = gameState.CurrentPlayer;
            Space space = gameState.Board.State[CommandInterpreter.ParamsToHex(parameters.Skip(1).Take(3).ToList())];
            
            Token currentToken = space.Token;
            Token nextToken = currentToken + 1;

            if (nextToken == Token.Score)
            {
                player.SubtractLightPoints((int)nextToken);
                player.AddScore(space.ScoreValue, gameState.ScoreTokens);

                player.ShopAddToken(currentToken);
                space.Clear();
                gameState.Board.UpdateShadows();
                return new CommandResponse(CommandState.GameStateUpdated);
            }

            player.SubtractLightPoints((int)nextToken);
            player.Hand.Remove(nextToken);
            space.Set(player.Team, nextToken);
            player.UsedSpaces.Add(space);
            player.ShopAddToken(currentToken);

            gameState.Board.UpdateShadows();
            return new CommandResponse(CommandState.GameStateUpdated);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "q r s", "Grows the given cube coordinate.");
        }
    }
}
