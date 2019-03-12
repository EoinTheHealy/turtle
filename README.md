# turtle

## Usage

```
  --settings    Required. The settings file.

  --moves       Required. The moves file.

  --draw        Draws the board.

  --help        Display this help screen.

  --version     Display version information.
```

## Settings file
```
#
# Notation:
#	- Empty Tile
#	* Mine
#	e Exit
#	^|v|<|> The players starting tile and direction (North,South,East,West)
#
-----
^*-*-
----e
---*-
```

## Moves file
```
Move
Rotate
Move
Move
Move
Move
Rotate
Move
Move
```

## Sample output
```
.\TurtleChallengeApp.exe --settings Samples/game-settings.txt --moves Samples/moves.txt --draw > sampleOutput.txt

Start position
-----
^*-*-
----e
---*-

After move 1: Move
^----
-*-*-
----e
---*-

After move 2: Rotate
>----
-*-*-
----e
---*-

After move 3: Move
->---
-*-*-
----e
---*-

After move 4: Move
-->--
-*-*-
----e
---*-

After move 5: Move
--->-
-*-*-
----e
---*-

After move 6: Move
---->
-*-*-
----e
---*-

After move 7: Rotate
----v
-*-*-
----e
---*-

After move 8: Move
-----
-*-*v
----e
---*-

After move 9: Move
-----
-*-*-
----v
---*-

Game finished in state: Success
Press enter to exit
```