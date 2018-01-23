using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        public Direction SunDirection { get; private set; }

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

            SunDirection = Direction.North;
        }

        public void AdvanceSunPosition()
        {
            SunDirection = (Direction)(((int)++SunDirection) % Enum.GetNames(typeof(Direction)).Length);
            UpdateShadows();
        }

        public void UpdateShadows()
        {
            switch (SunDirection)
            {
                case Direction.North:
                    State.Values.Where(s => s.Hex.Q == -BoardRadius || s.Hex.R == BoardRadius)
                        .ToList().ForEach((space) => { CastLight(space, GetOppositeDirection(SunDirection)); });
                    break;
                case Direction.NorthEast:
                    State.Values.Where(s => s.Hex.S == -BoardRadius || s.Hex.R == BoardRadius)
                        .ToList().ForEach((space) => { CastLight(space, GetOppositeDirection(SunDirection)); });
                    break;
                case Direction.SouthEast:
                    State.Values.Where(s => s.Hex.S == -BoardRadius || s.Hex.Q == BoardRadius)
                        .ToList().ForEach((space) => { CastLight(space, GetOppositeDirection(SunDirection)); });
                    break;
                case Direction.South:
                    State.Values.Where(s => s.Hex.R == -BoardRadius || s.Hex.Q == BoardRadius)
                        .ToList().ForEach((space) => { CastLight(space, GetOppositeDirection(SunDirection)); });
                    break;
                case Direction.SouthWest:
                    State.Values.Where(s => s.Hex.R == -BoardRadius || s.Hex.S == BoardRadius)
                        .ToList().ForEach((space) => { CastLight(space, GetOppositeDirection(SunDirection)); });
                    break;
                case Direction.NorthWest:
                    State.Values.Where(s => s.Hex.Q == -BoardRadius || s.Hex.S == BoardRadius)
                        .ToList().ForEach((space) => { CastLight(space, GetOppositeDirection(SunDirection)); });
                    break;
            }
        }

        private Direction GetOppositeDirection(Direction direction)
        {
            int numDirections = Enum.GetNames(typeof(Direction)).Length;
            return (Direction)(((int)SunDirection + numDirections / 2) % numDirections);
        }

        private void CastLight(Space space, Direction direction)
        {
            var shadowCount = 0;
            Space currentSpace = space;

            while (true)
            {
                if (shadowCount > 0)
                {
                    currentSpace.IsLit = false;
                    shadowCount--;
                }
                else
                {
                    currentSpace.IsLit = true;
                }

                if (currentSpace.Token != Token.None)
                {
                    shadowCount = Math.Max((int)currentSpace.Token, shadowCount);
                }

                Hex nextHex = Hex.Neighbor(currentSpace.Hex, direction);
                Space nextSpace;
                if (!State.TryGetValue(nextHex, out nextSpace)) return;
                currentSpace = nextSpace;
            }
        }

        public string SpacesHumanReadable()
        {
            StringBuilder board = new StringBuilder();
            board.AppendLine(string.Format("Sun is to the {0}.", SunDirection));

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

        public string HexesHumanReadable()
        {
            StringBuilder board = new StringBuilder();
            for (int q = -BoardRadius; q <= BoardRadius; q++)
            {
                int r1 = Math.Max(-BoardRadius, -q - BoardRadius);
                int r2 = Math.Min(BoardRadius, -q + BoardRadius);
                board.Append("".PadLeft(Math.Abs(q)*6 + 12));

                for (int r = r1; r <= r2; r++)
                {
                    var hex = new Hex(q, r, -q - r);
                    Space space;
                    State.TryGetValue(hex, out space);

                    board.Append(hex + "  ");
                }

                board.AppendLine();
                board.AppendLine();
            }

            return board.ToString();
        }

        public string ShadowsHumanReadable()
        {
            StringBuilder board = new StringBuilder();
            board.AppendLine(string.Format("Sun is to the {0}.", SunDirection));

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

                    string s = string.Format("{0}{1}", space.IsLit ? "O" : "X", space.Token == Token.None ? "-" : ((int)space.Token).ToString());
                    board.Append(s + "  ");
                }

                board.AppendLine();
                board.AppendLine();
            }

            return board.ToString();
        }

        public override string ToString()
        {
            return SpacesHumanReadable();
        }
    }
}
