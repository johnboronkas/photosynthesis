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

## bots todo list (John)

- [ ] create random bot as reference
- [ ] bots can be added to the game via the AddPlayer command
  - [ ] add argument to AddPlayer that accepts a name and load that bot if it exists, use that player's name alongside the player's color (ie, barabbas/Blue)
    - human players may have a name if it doesn't conflict with a bot's name
- [ ] each bot is put into a cs file named whatever their name is (ie, bots/barabbas.cs)
  - this cs file is the entrypoint for each bot (using cs events)

- [ ] during the game, if the current player is a bot, then use the 'make move' (else use the cli intrepreter (since it's a human player))
- [ ] during the game, if the current player is a bot, set a timer to ensure their move is under the configurable time limit, pass if it elapses
  - remember that they can send a move list without a pass at the end, get a response, then keep moving
  - put in GameState so bots have access to it and the current move timer
- [ ] provide method to get access to a directory for the bot to store temp files (ie, botdirs/barabbas/)
  - [ ] create the directory when the bot is added to the game
  - [ ] clear the directory at the end of the game
  - [ ] add command that clears all bot temp directories

## todo

- [ ] update rules from V1 to V2 of the rulebook (just did a major refactor of the rules/command sections, sorry) (Andrew)
- [ ] check game file to ensure it is suitable for machine learning purposes (rework and slim down as necessary) (Andrew?/entire ML group?)
- [ ] need a 'load' and 'next' command for game files to allow people to go into an after-action report mode with just show commands and next
  - make unique names for the game files based on who is in the match and the timestamp
- [ ] add instructions on the readme of how to make a bot
- [ ] add link to version 2.0 rules for the game
- [ ] serialize gamestate and all related classes to and from json
  - [ ] use this to pass a deep copy of the game state to the bots and have bots return a move list
  - [ ] update tournament rules
- [ ] setup rest endpoints and provide methods for calling out to an endpoint to do posts or gets for bots
  - [ ] update sample bot to use them

### stretch goals

- [ ] Move terminal commands into custom terminal module (so we can turn them off or redirect output to an interface, log file, or something down the line)
  - Use my terminal package?
- [ ] Colors for terminal interface output
  - Use my terminal package?
- [ ] 2D interface
- [ ] REST endpoints for bots in other languages / remote play
- [ ] Client/server socket connections for networked play
- [ ] Allow changing of the board size in setup
- [ ] Save/Load and replay mode
