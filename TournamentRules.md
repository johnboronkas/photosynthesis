# Tournament

## Prizes

Based on the number of entries we get, there will be prizes for the top bots.

## Rules

1. GameState is the actual GameState used by the game engine, so don't mess with it.
   - You may access and look at anything within it, but may not modifiy it.
   - There are no automated checks for this because deep copies are a pita and I don't feel like implementing momentos, serialization, or hashes.
2. I will be doing code reviews for cheats before every match, so please play by the rules.
3. Feel free to go crazy. If you want to call out to a super computer somewhere to run some calulcation, go for it.
   - If you want hooks into another language, go for it.
   - You must provide startup instructions for any addional program you want me to run.
4. Don't do anything funny with looking for certain bot names or messing with any directory on the computer other than the one provided to you.
   - IE, bots should not be conditionally teaming up based on bot names.
5. A bot that fails to finish their move within one minute will automatically be passed.
6. All source code and supporting files & libraries, even files/code that are executed remotely, must be and remain under 10GB uncompressed.
   - So, if you will be generating files, maintaining a database, or so on, ensure that it never exceeds 10GB while the game is being played.
7. Code must be checked in or otherwise submitted by 9:00pm on the night of your match.
   - I'll take whatever cut was available at 9:00pm or the last one that was sent.
   - You don't need to check your bot into the photosynthesis repository for competitive reasons, but it should be somewhere where I have access to it (or just emailed to me).

I'm always available for questions or reviews if you are unsure if something
you are doing is legal or not.

Each player involved with a match will recieve all of the related replay files.

## How to Win

### Group Stage

Bots will be randomly divided and placed into groups of 5.
Each group will consist of a round-robin of 1v1, 3-player, and 4-player games using the advanced ruleset (all unique combinations).
(That is, your bot will play 4 1v1 games, 6 3-player games, and 4 4-player games.)

- Winners of each mach will be awarded points:
  - 1v1 (320 pts total):
    - Win:  80 pts
    - Loss:  0 pts
    - Draw: Split the tie position's points

  - 3-player (300/120 pts total):
    - Win:  50 pts
    - 2nd:  20 pts
    - Loss:  0 pts
    - Draw: Split the tie position's points

  - 4-player (280/120/40 pts total):
    - Win:  70 pts
    - 2nd:  30 pts
    - 3rd:  10 pts
    - Loss:  0 pts
    - Draw: Split the tie position's points

A perfect score for the group stage is 900 points with 1,180 points able to be earned.

### Elimination Stage

Depending on the number of submissions, the bots with the most points will move on to an elimination stage to get down to the top-2 bots.
There will be a variety of 1v1, 3-player, and 4-player matches where the losing bot gets eliminated until only 2 bots remain.

Points are still earned by bots using the same group stage rules to help rank them and break ties.

TODO Details to come based on the number of submissions.

### Finals

The remaining 2 bots from the elimination stage will move on to the finals.

The finals will be a best-of-7 series of 1v1 games with alternating starting players.

Each of the 2 final bots will be put into a single-player game where they will attempt to score as many points as possible before the end of the game.
The winning bot's owner will get to choose if they want to go first or second during the first game of the best-of-7 series.
If tied, it will be based on the number of points earned during the elimination stage.

## Schedule

TBD
