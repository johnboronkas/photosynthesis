﻿using System;
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
        private const int BoardRadius = 3;

        public Dictionary<Hex, Space> State { get; private set; }

        /// <summary>
        /// Creates an empty board with the sun positioned to the North (top-right) of the board.
        /// </summary>
        public Board()
        {
            State = new Dictionary<Hex, Space>();
            for (int q = -BoardRadius; q <= BoardRadius; q++)
            {
                int r1 = Math.Max(-BoardRadius, -q - BoardRadius);
                int r2 = Math.Min(BoardRadius, -q + BoardRadius);
                for (int r = r1; r <= r2; r++)
                {
                    var hex = new Hex(q, r, -q - r);
                    var scoreValue = (BoardRadius + 1) - Hex.Distance(hex, Hex.Zero());
                    State.Add(hex, new Space(hex, scoreValue));
                }
            }
        }

        public override string ToString()
        {
            StringBuilder board = new StringBuilder();
            for (int q = -BoardRadius; q <= BoardRadius; q++)
            {
                int r1 = Math.Max(-BoardRadius, -q - BoardRadius);
                int r2 = Math.Min(BoardRadius, -q + BoardRadius);
                board.Append("".PadLeft(Math.Abs(q) * 2));

                for (int r = r1; r <= r2; r++)
                {
                    var hex = new Hex(q, r, -q - r);
                    Space space;
                    State.TryGetValue(hex, out space);

                    board.Append(space + "  ");
                }

                board.AppendLine();
                board.AppendLine();
            }

            return board.ToString();
        }
    }
}