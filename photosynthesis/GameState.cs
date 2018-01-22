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
        public Dictionary<Team, Player> TeamToPlayer;
        public int PlayerNumberFirstToMove { get; private set; }
        public int CurrentPlayerNumber { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public Board Board { get; private set; }
        public ScoreTokens ScoreTokens { get; private set; }
        public GameFile GameFile { get; private set; }

        public GameState(List<Player> players, Board board, ScoreTokens scoreTokens, GameFile gameFile)
        {
            CurrentRound = 0;

            Players = players;
            TeamToPlayer = new Dictionary<Team, Player>();
            players.ForEach((player) =>
            {
                TeamToPlayer.Add(player.Team, player);
            });

            PlayerNumberFirstToMove = 0;
            CurrentPlayerNumber = 0;
            CurrentPlayer = Players[CurrentPlayerNumber];
            Board = board;
            ScoreTokens = scoreTokens;
            GameFile = gameFile;
        }

        public void EndTurn()
        {
            CurrentPlayerNumber = ++CurrentPlayerNumber % Players.Count;
            
            if (CurrentPlayerNumber == PlayerNumberFirstToMove)
            {
                PlayerNumberFirstToMove = ++CurrentPlayerNumber % Players.Count;
                Board.AdvanceSunPosition();

                if (Board.SunDirection == Direction.North)
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
            foreach (Space space in Board.State.Values)
            {
                Player player;
                if (TeamToPlayer.TryGetValue(space.Team, out player))
                {
                    if (space.IsLit)
                    {
                        player.AddLightPoints((int)space.Token);
                    }
                }
            }
        }

        public void EndOfGame()
        {
            // TODO Tally score.
        }
    }
}
