# Protect Humanity
Protect Humanity is a role-playing game where the player plays a robot who travels through a dangerous, apocalyptic world. Humanity is escaping to Mars. All of the humans have left Earth or have been mutated into horrifying monsters, except for one. Your job is to escort the last living human, safely to the launchpad. 

The robot leads the team of two with the human following behind. They travel through the world, encountering enemies and items. Colliding with an item allows the player to press a button “E” to pick it up. In the corner of the screen there is a button to open inventory. When the player picks up an item it is added there. The player can equip only a single item at a time. Equipping an item updates the player's stats.

The map includes enemy encounters that enter the player into a turn-based battle. To initiate combat, the player moves until the robot collides with an enemy. A pop-up comes up to choose whether to initiate combat. If the player selects “start", the fight starts after a brief transition. If the player selects "run", the pop-up closes. For each turn, the player must choose an action to keep the human alive. The player starts with 3 options every turn: defend, taunt, or empower. The enemies either target the robot or the human. Each round, the human will also act, though they may not always be helpful. His move will be randomly generated. He has a percent chance to attack or do something stupid. During a battle, a text box shows the actions taken by each participant. If the robot dies in combat, but the human manages to defeat the enemy, a new identical robot replaces the old one.

For tips on how to play, check out the [Player Guide](https://github.com/LitchDoctor/winter2025-group2-rpg/blob/main/Documentation/Player_Guide.md)

## Documentation
For more information about the whole project, check out the [Living Document](https://github.com/LitchDoctor/winter2025-group2-rpg/blob/main/Documentation/Living%20Document.pdf)

For details on how to build your own versions of the game, view the [Developer Documentation](https://github.com/LitchDoctor/winter2025-group2-rpg/blob/main/Documentation/Developer_Documentation.md)

For installing and distributing the game, view the [Setup Page](https://github.com/LitchDoctor/winter2025-group2-rpg/blob/main/Documentation/SETUP.md)

For downloading the playable game, view the [Install Page](https://github.com/LitchDoctor/winter2025-group2-rpg/blob/main/Documentation/INSTALL.md)

## Repository and Trello
[Github](https://github.com/LitchDoctor/winter2025-group2-rpg)

[Trello](https://trello.com/b/aRKvqJ4l/pt-2-group-2)

# How to Test
1. Use "WASD" to move your character around the map
2. Pick up your first item by pressing "E"
3. Press "I" to open and close your inventory
    * Experiment with various inventory features (equip, unequip, look at item description)
3. Roam the map until you encounter your first enemy
4. When you collide with an enemy, an encounter pop-up will appear with the options to "start" or "run"
    * Click "start" to engage in combat
5. Run through an iteration of combat making sure to utilize all of the available combat features to defeat the enemy
5. Once an enemy is defeated, you're returned to the main scene where you can continue playing

# Operational use cases

1. Player movement
* User is able to move the player model around using "WASD"

2. Enter a battle
* User is able to "encounter" an enemy and choose whether or not they'd like to battle the monster
* There are two options listed: "start" and "run"
    * "start" will send the player into the combat scene
    * "run" will close the encounter UI and returns the player to the main scene

3. Battle option: Defend
* During combat, user is able to select the "defend" option to take reduced damage from the enemy

4. Defeating an enemy
* When the user successfully defeats an enemy (by reducing enemy HP to 0), the user is sent back to the main scene

5. Pick up an item
* User is able to pick up an item which is stored in the inventory by pressing "E" when an item is in range

6. Player Defeat
* When user HP reaches 0 (after both human and robot is defeated), a message is printed stating "you have been defeated"
* After message is printed, user is returned to the main menu

# Non-operational use cases

7. Levelling up
* User experience and level up system has yet to be implemented
