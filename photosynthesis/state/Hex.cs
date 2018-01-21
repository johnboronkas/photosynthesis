using System;
using System.Collections.Generic;

namespace photosynthesis.state
{
    public class Hex
    {
        public int Q { get; private set; }
        public int R { get; private set; }
        public int S { get; private set; }

        public Hex(int q, int r, int s)
        {
            if (q + r + s != 0) throw new ArgumentException("q, r, and s must add up to 0 for the cube coordinate system.");

            Q = q;
            R = r;
            S = s;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Hex))
            {
                return false;
            }

            Hex other = obj as Hex;
            return (Q == other.Q && R == other.R && S == other.S);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Q.GetHashCode();
            hash = (hash * 7) + R.GetHashCode();
            hash = (hash * 7) + S.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", Q, R, S);
        }

        public static Hex Zero()
        {
            return new Hex(0, 0, 0);
        }

        public static Hex operator +(Hex h1, Hex h2)
        {
            return new Hex(h1.Q + h2.Q, h1.R + h2.R, h1.S + h2.S);
        }

        public static Hex operator -(Hex h1, Hex h2)
        {
            return new Hex(h1.Q - h2.Q, h1.R - h2.R, h1.S - h2.S);
        }

        public static Hex operator *(Hex h, int k)
        {
            return new Hex(h.Q * k, h.R * k, h.S * k);
        }

        public static int Length(Hex hex)
        {
            return (Math.Abs(hex.Q) + Math.Abs(hex.R) + Math.Abs(hex.S)) / 2;
        }

        public static int Distance(Hex h1, Hex h2)
        {
            return Length(h1 - h2);
        }

        private static List<Hex> Directions = new List<Hex> { new Hex(1, 0, -1), new Hex(1, -1, 0), new Hex(0, -1, 1),
                                                              new Hex(-1, 0, 1), new Hex(-1, 1, 0), new Hex(0, 1, -1) };

        /// <summary>
        /// Top-right is 0, bottom-right is 1, and so on (clockwise).
        /// </summary>
        private static Hex Direction(int direction)
        {
            return Directions[direction];
        }

        /// <summary>
        /// Top-right is 0, bottom-right is 1, and so on (clockwise).
        /// </summary>
        public static Hex Neighbor(Hex hex, int direction)
        {
            return hex + Direction(direction);
        }
    }
}
