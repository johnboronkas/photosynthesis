namespace photosynthesis.state
{
    /// <summary>
    /// Sun starts to the North, and moves clockwise around the board.
    /// 0 is the starting position, 1 is the next, and so on.
    /// </summary>
    public enum SunPosition : int
    {
        North = 0,
        NorthEast,
        SouthEast,
        South,
        SouthWest,
        NorthWest,
    }
}
