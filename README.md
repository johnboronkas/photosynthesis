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

- Enter the command `dotnet run` to build & run the program (can use `dotnet build` to just build)

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

## bots todo list

- [ ] bots can be added to the game via the AddPlayer command
  - [ ] add argument to AddPlayer that accepts a name and load that bot if it exists, use that player's name alongside the player's color (ie, barabbas/Blue)
    - players should have a 'make move' function and a 'is bot' function
    - human players may have a name if it doesn't conflict with a bot's name
- [ ] each bot is put into a cs file named whatever their name is (ie, bots/barabbas.cs)
  - this cs file is the entrypoint for each bot (using cs events)
- [ ] during the game, if the current player is a bot, then use the 'make move' (else use the cli intrepreter)
- [ ] during the game, if the current player is a bot, set a timer to ensure their move is under the configurable time limit, pass if it elapses
  - remember that they can send a move list without a pass at the end, get a response, then keep moving
  - put in GameState so bots have access to it and the current move timer
- [ ] provide method to get access to a directory for the bot to store temp files (ie, botdirs/barabbas/)
  - [ ] create the directory when the bot is added to the game
  - [ ] clear the directory at the end of the game
  - [ ] add command that clears all bot temp directories

## todo

- [X] make game configuation command
- [ ] update rules from V1 to V2 of the rulebook
- [ ] make sure the game state that the bot gets is a deep copy, then apply their moves to the real gamestate
- [ ] bots are given gamestate. must return list of strings as a move that ends with a pass. make class to make creating this list easier (ie, add move (new buysmalltree()))
  - [ ] bots may also send just 1 string/action and, if it is still their turn, they'll recieve an updated gamestate to make their next move until a pass is recieved
- [ ] use csharp events for make setup move or make actual move
- [ ] provide random bot impl as reference
- [ ] check game file to ensure it only has the necessary moves for playback
- [ ] write rules for bot competition (speed per turn and delivery size limit) and send email blast

### stretch goals

- [ ] Singleplayer challange
  - In a one player game, use all bots to see which scores the most amount of points
- [ ] Move terminal commands into custom terminal module (so we can turn them off or redirect output to an interface, log file, or something down the line)
  - Use my terminal package?
- [ ] Colors for terminal interface output
  - Use my terminal package?
- [ ] 2D interface
- [ ] REST endpoints for bots in other languages / remote play
- [ ] Client/server socket connections for networked play
- [ ] Allow changing of the board size in setup
- [ ] Save/Load and replay mode
