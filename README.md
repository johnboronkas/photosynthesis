# building
Visual Studio Community 2017 - .NET 4.6.1

# physical setup
Follow the advanced rules and setup with the board facing you and the sun start position at the top-right hand courner of the board.

# game file
A list of moves from an initial gamestate that can be used to save, restore, or replay a game. Much like [chess notation](https://en.wikipedia.org/wiki/Chess_notation).

In the form:
`round sunPosition player action`

# game board
A hex-grid representation of the game board. Using the "pointy topped" version with cube coordinates.

Borrowed from https://www.redblobgames.com/grids/hexagons/.

# playing
`Help` shows a list of available commands and their descriptions.
Illegal moves have no effect on your turn.
