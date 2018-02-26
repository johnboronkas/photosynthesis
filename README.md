# building
Visual Studio Community 2017 - .NET 4.6.1
	- Install the [.NET Core SDK](https://www.microsoft.com/net/learn/get-started/windows)
	- Install [Visual Studio Code](https://code.visualstudio.com/)
	- Install the C# VS Code extension by Microsoft
	- Open the top-level photosynthesis folder in VS Code
	- Press Ctrl + ` to open the terminal
	- Enter the command `dotnet run` to run the program

# project vision
Use a standard notation to store games. Use various non-deterministic AIs to generate games. Feed generated games into a machine learning algorithm. Face machine learning algorithm against itself to continue learning.

# physical setup
Setup with the board facing you and the sun start position at the top-right hand courner of the board.

# settings
Can set debug mode and advanced rules in `GameState`.

# game file
A list of moves from an initial gamestate that can be used to save, restore, or replay a game. Much like [chess notation](https://en.wikipedia.org/wiki/Chess_notation).

In the form:
`player action`

# game board
A hex-grid representation of the game board. Using the "pointy topped" version with cube coordinates.

Borrowed from https://www.redblobgames.com/grids/hexagons/.

# playing
`Help` shows a list of available commands and their descriptions.
Illegal moves have no effect on your turn.

# todo / notes
- make consts changeable during setup, but not during the game
- make sure the game state that the bot gets is a deep copy, then apply their moves to the real gamestate
- bots are given gamestate. must return list of strings as a move that ends with a pass. make class to make creating this list easier (ie, add move (new buysmalltree()))
- use csharp events for make setup move or make actual move
- provide random bot impl as reference
- add command set enum (ie gamesetup command, play command, debug, etc)
- port to Core
