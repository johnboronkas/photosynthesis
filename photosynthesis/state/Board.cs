using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photosynthesis.state
{
    /// <summary>
    /// Represented as a pointy topped hex grid using cube coordinates.
    /// https://www.redblobgames.com/grids/hexagons/
    /// </summary>
    public class Board
    {
        public Dictionary<Hex, Space> State { get; private set; }

        public Board()
        {
            State = new Dictionary<Hex, Space>();
        }
    }
}
