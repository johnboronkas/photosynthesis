# building
Visual Studio Community 2017 - .NET 4.6.1

# physical setup
Follow the advanced rules and setup with the board facing you and the sun start position at the top-right hand courner of the board.

# game file
A list of moves from an initial gamestate that can be used to save, restore, or replay a game. Much like [chess notation](https://en.wikipedia.org/wiki/Chess_notation).

# game board
A hex-grid representation of the game board. Using the "pointy topped" version with cube coordinates.

Borrowed from https://www.redblobgames.com/grids/hexagons/.

# playing
`help` shows a list of available commands.
 - `buy tokenID` buys an item from your shop if you have the available light points.
 - `upgrade p q r` upgrades the given cube coordinate.
 - `seed srcP srcQ srcR dstP dstQ dstR` shoots a seed from the source hex to the destination hex.
 
The rest of the commands are for human players to help visualise the game. Use of a physical copy of the game is highly recommended.

Illegal moves have no effect on your turn.
