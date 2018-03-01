using System;

namespace photosynthesis
{
    public static class FlagExtensions
    {
        public static bool IsSet(this GameMode e, GameMode mode)
        {
            return e.HasFlag(mode);
        }

        public static void Set(this GameMode e, GameMode mode, bool value)
        {
            if (value)
            {
                e |= mode;
            }
            else
            {
                e &= ~mode;
            }
        }

        public static bool IsSamePhase(this GameMode e, GameMode other)
        {
            var mask = GameMode.Config | GameMode.Init | GameMode.Playing;

            var actualPhase = e & mask;
            var otherPhase = e & mask;

            return actualPhase.Equals(otherPhase);
        }
    }
}
