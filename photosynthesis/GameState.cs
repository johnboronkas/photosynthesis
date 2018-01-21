using photosynthesis.state;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photosynthesis
{
    public class GameState
    {
        public const int MaxRounds = 4;
        public int CurrentRound { get; private set; }

        public List<Player> Players { get; private set; }
        public int CurrentPlayerNumber { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public Board Board { get; private set; }
        public GameFile GameFile { get; private set; }

        public GameState(List<Player> players, Board board, GameFile gameFile)
        {
            CurrentRound = 0;
            Players = players;
            CurrentPlayerNumber = 0;
            CurrentPlayer = Players[CurrentPlayerNumber];
            Board = board;
            GameFile = gameFile;
        }

        public void EndTurn()
        {
            CurrentPlayerNumber = ++CurrentPlayerNumber % Players.Count;
            CurrentPlayer = Players[CurrentPlayerNumber];
            
            if (CurrentPlayerNumber == 0)
            {
                Board.AdvanceSunPosition();

                if (Board.CurrentSunPosition == SunPosition.North)
                {
                    CurrentRound++;

                    if (CurrentRound >= MaxRounds)
                    {
                        EndOfGame();
                    }
                }
            }

            CollectLightPoints();
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
