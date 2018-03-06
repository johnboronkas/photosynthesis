# photosynthesis

## building / running

- Install the [.NET Core SDK](https://www.microsoft.com/net/learn/get-started/windows)
- Install [Visual Studio Code](https://code.visualstudio.com/)
- Open the top-level photosynthesis folder in VS Code
- Press Ctrl + \` to open a terminal
- Enter the following command to install the recommended VS Code plugins:

```bash
code --install-extension DavidAnson.vscode-markdownlint --install-extension jchannon.csharpextensions --install-extension josephwoodward.vscodeilviewer --install-extension k--kato.docomment --install-extension ms-vscode.csharp --install-extension PKief.material-icon-theme --install-extension reflectiondm.classynaming
```

- Enter the command `dotnet run` to run the program (can use `dotnet build` to just build)

## project vision

Use a standard notation to store games. Use various non-deterministic AIs to generate games. Feed generated games into a machine learning algorithm. Face machine learning algorithm against itself to continue learning.

## physical setup

Setup with the board facing you and the sun start position at the top-right hand courner of the board.

## game file

A list of moves from an initial gamestate that can be used to save, restore, or replay a game. Much like [chess notation](https://en.wikipedia.org/wiki/Chess_notation).

In the form:
`player action`

## game board

A [hex-grid representation](https://www.redblobgames.com/grids/hexagons/) of the game board. Using the "pointy topped" version with cube coordinates.

## playing

`Help` shows a list of available commands and their descriptions.
Illegal moves have no effect on your turn.

## todo

[] make game configuation command
[] make sure the game state that the bot gets is a deep copy, then apply their moves to the real gamestate
[] bots are given gamestate. must return list of strings as a move that ends with a pass. make class to make creating this list easier (ie, add move (new buysmalltree()))
  [] bots may also send just 1 string/action and, if it is still their turn, they'll recieve an updated gamestate to make their next move until a pass is recieved
[] use csharp events for make setup move or make actual move
[] provide random bot impl as reference

### stretch goals

[] Colors for termainal interface output
[] 2D interface
[] REST endpoints for bots in other languages / remote play
[] Client/server socket connections for networked play
[] Allow changing of the board size in setup
