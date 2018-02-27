using System;

namespace photosynthesis
{
    /**
    * Program-wide settings and state tracking.
    */
    [Flags]
    public enum GameMode
    {
        // Use advanced rules?
        Advanced = 1,
        // Are debug mode commands allowed?
        Debug = 2,
        // Currently configurating a game?
        Config = 4,
        // Currently in the setup portion of a game (placing starting trees)?
        Init = 8,
        // Currently playing a game?
        Playing = 16,
        // Using a human-focued interface?
        HumanFriendly = 32,
    }
}
