# Developer Guide
This document provides an overview for the development process of Protect Humanity, using Unity Hub. It runs through downloading and contributing to the game, architecture, and code structure.

## Downloading Project
The following walks through downloads and developing other versions of Protect Humanity.

### Required Downloads
The following downloads are necessary to edit and develop different versions

* [Unity Hub](https://unity.com/download)
  * To avoid compatibility issues, make sure to download version 6000.0.34f1

* [Visual Studio Code](https://code.visualstudio.com/download)

### Developing and Building New Versions
After downloading Unity Hub and Visual Studio Code, follow the below steps to make new changes to the project.

1. Clone or Fork the repository
1. Open up Unity Hub and click on "Add" then select "Add project from disk"
1. Open the cloned repository directory and select "Protect Humanity"
1. From here, the project will open up and you will be able to edit the game

### Building Project Executable
Building a project executable must be done through Unity. After opening the project in Unity, follow these steps.

1. Select "File" in the upper left
1. From the dropdown menu, select "Build Profiles"
1. Select the target platform from the menu on the left side
1. Click "Switch Platform"
1. After the platform is switched, view the "Scene List"
1. Click the checkbox next to all scenes that you want to include
1. (OPTIONAL) Open the player settings to change product name, version, resolution, etc.
1. When finished adjusting settings, click "Build" or "Build and Run"

## Program Architecture
Protect Humanity follows an event-driven approach to architecture. It uses various event listeners with buttons to interact with different portion of the program. There are many different connections between the components, with the main interactions shown below.

Main Events in The Overworld:
* Running into an enemy and pressing "start" -> Entering a combat scene
* Standing next to an item and pressing "e" -> Picking up an item and moving it to inventory

Main Events in Combat Scenes:
* Clicking "Buff" -> Increasing Human damage
* Clicking "Defend" -> Enemy deals reduced damage to human character
* Clicking "Taunt" -> Enemy is forced to attack the player
* Clicking "Stun" -> There is a 60% chance the Enemy will skip its attack
* Clicking "Heal" -> The human will be healed according the the player's energy value
* Enemy loses all health -> User returns to the map to continue playing
* User character loses all health -> User loses the game and is sent back to the Main Menu

Main Events in Main Menu:
* Clicking "Play" -> Sends user into the map to play the game
* Clicking "Controls" -> Opens up a page full of game controls
* Clicking "Quit" -> Exit out of the game completely

## File Structure
Nearly all files that are used for making the game fall under the assets directory. Below is a list showing what each directory inside of assets contains.

Cainos
* Sprites used for map design

Dungeon Tiles
* Map background tiles

GameInputControllerIcons
* All types of computer keys for the controls menu

Gutty Kreum
* Tiles used for border of map

russian_cars_pixelart
* Car objects used on map

Scenes
* All menus, maps, and battles

Scripts
* Functionality for all interactive components of the game

Settings
* Various settings for shaders, compatibility, build configurations, etc.

Sprites
* User-created art for items, enemies, and characters

TechnoGami
* Images used for buttons on the menu pages

TextMesh Pro
* Required fonts, prefabs, shaders, and sprites for producing on-screen text

Unity.VisualScripting.Generated
* Required for allowing visual scripts to interact with normal user-created scripts
