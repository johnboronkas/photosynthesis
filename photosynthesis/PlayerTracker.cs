using photosynthesis.state;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photosynthesis
{
    public class PlayerTracker
    {
        public List<Player> Players { get; private set; }
        public int CurrentPlayerNumber { get; private set; }
        public Player CurrentPlayer { get; private set; }

        public PlayerTracker(List<Player> players)
        {
            Players = players;
            CurrentPlayerNumber = 0;
            CurrentPlayer = Players[CurrentPlayerNumber];
        }

        public void AdvanceToNextPlayer()
        {
            CurrentPlayerNumber = ++CurrentPlayerNumber % Players.Count;
            CurrentPlayer = Players[CurrentPlayerNumber];
        }
    }
}
