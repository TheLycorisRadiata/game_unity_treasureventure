# TREASURE VENTURE

- Project in collaboration with [Mourat](https://github.com/Mourat) and [Doramail](https://github.com/doramail).
- Objective: Using Unity, create a small 3D game with a menu and the new Unity input system.
- Secondary objective: Learn Git and teamwork.
- Deadline: Thursday Dec 22nd 2022 at 9 AM.
- Link to repo: https://github.com/TheLycorisRadiata/game_unity_collab_treasureventure

---

- Project type: 3D game.
- Genre: Platformer.
- Tech: Unity engine (2021.3.15f1).
- Inspirations: Super Mario 64, Spyro The Dragon, Crash Bandicoot.

---

## EXISTING FEATURES

**INPUT SYSTEM**
- [WASD/Arrow keys] The player moves forward and backwards, and rotates to the left and to the right.
- [Q/E] The player steps to the left and to the right.
- [Space Bar] The player jumps.
- [F1] Toggle/Untoggle help mode (not developped yet).
- [F2] Switch between fixed and controllable camera rotation.
- [F11] Switch between fullscreen mode and windowed mode.

**CAMERA**
- The camera follows the player in 3rd person.

**INTERACTIONS**
- Doors open when the player gets close, and close when the player gets away.
- Certain objects can be pushed.
- Traps: Spike grate traps and spike block trap.
- The spike block trap breaks a bench when it falls on it.

**LIFE**
- The player has 3 lives, for 100 points each.
- The player can take damage. Once a life reaches 0 points, it gets lost.

---

## IMPORTANT TODO

**LIFE**
- Lives are represented by a heart icon.
- Whenever the player loses a life, they go back to the most recent checkpoint.
- When they no longer have any life, it's game over.

**COLLECTIBLE**
- Coin (value of 5) and gem (value of 15).
- When the level is completed, the player can buy bonuses (regen hearts, extra heart, etc).

**GOAL**
- Reaching the flag completes the level. There is no coin requirement.

**MENU**
- Splash Screen.
- Menu: Volume settings, etc.
- Help Key: It displays blinking arrows to guide to the goal. Disabled by default. There's a popup after a certain time asking if the player needs help.

