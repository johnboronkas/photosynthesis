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
`Help` shows a list of available commands.
 - `PlaceStartingTree p q r` places a small tree on the given cube coordinate. Can only be used on the outer rim of the board.
 - `Buy tokenID` buys an item from your shop if you have the available light points.
 - `Seed srcP srcQ srcR dstP dstQ dstR` shoots a seed from the source cube coordinate to the destination coordinate.
 - `Upgrade p q r` upgrades the given cube coordinate.
 - `Pass` ends the current player's turn and advances to the next player's turn. This may also move the sun or end the game.
 
The rest of the commands are for human players to help visualise the game. Use of a physical copy of the game is highly recommended.

Illegal moves have no effect on your turn.
