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
            var otherPhase = other & mask;

            /*
            * If actualPhase and otherPhase have at least 1 phase in common,
            * then we consider them the same.
            */
            return (actualPhase & otherPhase) > 0;
        }
    }
}
