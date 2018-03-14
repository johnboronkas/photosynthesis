using System.Collections.Generic;
using System.Linq;
using photosynthesis.interpreter;
using photosynthesis.interpreter.commands;
using photosynthesis.state;

namespace photosynthesis.bots
{
    /// <summary>
    /// All bots must extend this class.
    /// </summary>
    public abstract class Bot
    {
        /// <summary>
        /// This will be called during your turn to request what to do next.
        /// </summary>
        public abstract void MakeMoves(GameState gameState);

        private CommandInterpreter commandInterpreter;

        public Bot()
        {
            commandInterpreter = new CommandInterpreter();
        }

        /// <summary>
        /// Checks if able to place starting tree on provided hex.
        /// Starting trees may only be placed on the perimeter of the map.
        /// </summary>
        /// <param name="hex">The hex to attempt to place your starting tree on.</param>
        /// <param name="gameState">The GameState to test against.</param>
        /// <returns>True if this move is able to be used, otherwise false.</returns>
        protected bool CanPlaceStartingTree(Hex hex, GameState gameState)
        {
            var cmd = ("placestartingtree " + hex.AsCommandInput()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd, checkOnly: true) != CommandState.Failure;
        }

        /// <summary>
        /// Places starting tree on provided hex.
        /// Starting trees may only be placed on the perimeter of the map.
        /// </summary>
        /// <param name="hex">The hex to attempt to place your starting tree on.</param>
        /// <param name="gameState">The GameState to test against.</param>
        /// <returns>True if the move was performed, otherwise false.</returns>
        protected bool PlaceStartingTree(Hex hex, GameState gameState)
        {
            var cmd = ("placestartingtree " + hex.AsCommandInput()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd) != CommandState.Failure;
        }

        /// <summary>
        /// Checks if able to buy the given Token from your shop.
        /// </summary>
        /// <param name="token">The Token to buy.</param>
        /// <returns>True if the move is able to be used, otherwise false.</returns>
        protected bool CanBuy(Token token, GameState gameState)
        {
            var cmd = ("buy " + token.ToString()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd, checkOnly: true) != CommandState.Failure;
        }

        /// <summary>
        /// Buys the given Token from your shop.
        /// </summary>
        /// <param name="token">The Token to buy.</param>
        /// <returns>True if the move was performed, otherwise false.</returns>
        protected bool Buy(Token token, GameState gameState)
        {
            var cmd = ("buy " + token.ToString()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd) != CommandState.Failure;
        }

        /// <summary>
        /// Checks if able to grow the provided hex.
        /// </summary>
        /// <param name="hex">The hex to grow.</param>
        /// <returns>True if the move is able to be used, otherwise false.</returns>
        protected bool CanGrow(Hex hex, GameState gameState)
        {
            var cmd = ("grow " + hex.AsCommandInput()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd, checkOnly: true) != CommandState.Failure;
        }

        /// <summary>
        /// Grows the provided hex.
        /// </summary>
        /// <param name="hex">The hex to grow.</param>
        /// <returns>True if the move was performed, otherwise false.</returns>
        protected bool Grow(Hex hex, GameState gameState)
        {
            var cmd = ("grow " + hex.AsCommandInput()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd) != CommandState.Failure;
        }

        /// <summary>
        /// Checks if able to seed from one hex to another.
        /// </summary>
        /// <param name="from">The hex to seed from.</param>
        /// <param name="to">The hex to shoot the seed to.</param>
        /// <returns>True if the move is able to be used, otherwise false.</returns>
        protected bool CanSeed(Hex from, Hex to, GameState gameState)
        {
            var cmd = string.Format("{0} {1} {2}", "seed", from.AsCommandInput(), to.AsCommandInput()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd, checkOnly: true) != CommandState.Failure;
        }

        /// <summary>
        /// Seeds from one hex to another.
        /// </summary>
        /// <param name="from">The hex to seed from.</param>
        /// <param name="to">The hex to shoot the seed to.</param>
        /// <returns>True if the move was performed, otherwise false.</returns>
        protected bool Seed(Hex from, Hex to, GameState gameState)
        {
            var cmd = string.Format("{0} {1} {2}", "seed", from.AsCommandInput(), to.AsCommandInput()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd) != CommandState.Failure;
        }

        /// <summary>
        /// A Pass indicates the end of your turn, play will continue with the next player.
        /// Note that Passing is automagically done when placing your starting trees.
        /// </summary>
        protected void Pass(GameState gameState)
        {
            if (!gameState.GameMode.IsSet(GameMode.Playing)) return;
            commandInterpreter.DoAction(gameState, new List<string>() { "pass" });
        }
    }
}