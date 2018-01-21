using photosynthesis.state;
using System.Collections.Generic;

namespace photosynthesis
{
    public class GameState
    {
        public const bool DebugMode = true;
        public const bool AdvancedMode = true;

        public const int MaxRounds = AdvancedMode ? 4 : 3;
        public int CurrentRound { get; private set; }

        public List<Player> Players { get; private set; }
        public int PlayerNumberFirstToMove { get; private set; }
        public int CurrentPlayerNumber { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public Board Board { get; private set; }
        public GameFile GameFile { get; private set; }

        public GameState(List<Player> players, Board board, GameFile gameFile)
        {
            CurrentRound = 0;
            Players = players;
            PlayerNumberFirstToMove = 0;
            CurrentPlayerNumber = 0;
            CurrentPlayer = Players[CurrentPlayerNumber];
            Board = board;
            GameFile = gameFile;
        }

        public void EndTurn()
        {
            CurrentPlayerNumber = ++CurrentPlayerNumber % Players.Count;
            
            if (CurrentPlayerNumber == PlayerNumberFirstToMove)
            {
                PlayerNumberFirstToMove = ++CurrentPlayerNumber % Players.Count;
                Board.AdvanceSunPosition();

                if (Board.CurrentSunPosition == SunPosition.North)
                {
                    CurrentRound++;

                    if (CurrentRound >= MaxRounds)
                    {
                        EndOfGame();
                    }
                }

                CollectLightPoints();
            }

            CurrentPlayer = Players[CurrentPlayerNumber];
        }

        public void CollectLightPoints()
        {
            // TODO Collect light points for every player.
        }

        public void EndOfGame()
        {
            // TODO Tally score.
        }
    }
}
