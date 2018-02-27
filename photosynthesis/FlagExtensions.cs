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
    }
}
