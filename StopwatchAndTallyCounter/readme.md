# True Stopwatch and Tally Counter

Use the stopwatch and tally counter as an actual stopwatch and tally counter with client commands.

The mod tally counter lets you count up or down by any number. The stopwatch comes with a split function, a count-down mode, and a boss mode. The state of both are saved with each character.

Note that the stopwatch only counts in-game time. Pausing or leaving the game will also pause the stopwatch, and any game slowdown will slow the stopwatch too.

This mod is fully client-side and can be used in single player or any multiplayer server.

## Commands

Commands marked with a * are also available as keybindings.

### Stopwatch

* `/stopwatch hide` – show the normal stopwatch display.
* `/stopwatch show` – show the mod stopwatch display.
* `/stopwatch toggle`* – toggle between the normal and mod stopwatch display.
* `/stopwatch start` – starts the mod stopwatch.
* `/stopwatch stop` – stops the mod stopwatch.
* `/stopwatch startstop`* – starts the mod stopwatch or stops it if it is already running.
* `/stopwatch reset`* – stops and resets the mod stopwatch.
* `/stopwatch restart` – resets the mod stopwatch, then starts it.
* `/stopwatch split`* – marks a split, temporarily freezing or restoring the display while the stopwatch continues to run.
* `/stopwatch set [mins]|[mins]:[secs]` – sets the stopwatch to count down from the specified time.
* `/stopwatch boss` – toggles boss mode. This will automatically start the stopwatch when a boss is alive (even if one is already alive when the command is used), then stop the stopwatch and disable boss mode when no boss is alive any more.

### Tally counter

* `/counter hide` – show the normal counter display.
* `/counter show` – show the mod counter display.
* `/counter toggle`* – toggle between the normal and mod counter display.
* `/counter + [number]`* – adds the specified number (1 if no number is specified) to the count.
* `/counter - [number]`* – subtracts the specified number (1 if no number is specified) from the count.
* `/counter set [number]` – sets the count to the specified number.
* `/counter reset`* – sets the count to zero.
