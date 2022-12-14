# Simplon Group Project (Dec 2022)

- Deadline Friday 23rd
- If needed, clone from https://github.com/TheLycorisRadiata/simplon-dec2022

- Unity project type: 3D
- Genre: Platformer
- Inspirations: Mario 64, Classic Mario, Spyro The Dragon

## BASIC FEATURES

GOAL
- Reaching the flag completes the level. There is no coin requirement.

MENU
- Splash Screen.
- Menu: Volume settings, etc.
- Help Key: It displays blinking arrows to guide to the goal. Disabled by default. There's a popup after a certain time asking if the player needs help.

MOVEMENT
- Moving in 4 directions: forward, backward, step to the left, step to the right.
- Rotation left and right.
- Single jump.

INTERACTION
- Push objects and NOT pull them.

DECOR
- Static and moving platforms (solid and fragile).
- Jumper object: to jump higher and further.
- Bumper object: to push the player in the other direction (to mess with them).

LIFE
- The player has 3 lives (shown as a heart symbol). In code, each heart is represented by 100 points.
- The player can take damage. Once a heart reaches 0 points, it gets lost.
- Whenever the player loses a heart, they go back to the most recent checkpoint.
- When they no longer have any heart, it's game over.

COLLECTIBLE
- Coin (value of 5) and gem (value of 15).
- When the level is completed, the player can buy bonuses (regen hearts, extra heart, etc).

DAMAGES
- Holes that lead into the void (or just falling off the map)  
**--> Removes the last heart no matter how many points it had left.**
- Landmines  
**--> 30 points of damage.**
- Holes with spikes. The spikes are not there right off the bat, they show up when the player touches them, and the player is propeled upwards and receives damage.  
**--> 20 points of damage.**
- Enemies. They ignore us and follow their own path, and we get hurt upon contact with them.  
**--> 5 points of damage for the kinder one, and 10 points for the meaner.**
- Lava or any other type of "ground" that needs to be avoided  
**--> 10 points of damage.**

---

## ADDITIONAL FEATURES
- Double jump.
- Defeat enemies, for instance by jumping on top of them.
- Enemies that follow the player.
- Quicksand: ground that deals damage and it slows down the player as they try to get away.
- Setting difficulty in sub-menu (static/moving platforms, etc). This sub-menu is open at launch instead of letting the player guess its existence.
- Water (floating, swimming).

