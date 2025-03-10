# Developer Guide
This document provides an overview for the development process of Protect Humanity, using Unity Hub. It runs through downloading and contributing to the game, architecture, and code structure.

## Downloading Project
The following walks through downloads and developing other versions of Protect Humanity.

### Required Downloads
The following downloads are necessary to edit and develop different versions

* [Unity Hub](https://unity.com/download)
  * To avoid compatibility issues, make sure to download version 6000.0.34f1

* [Visual Studio Code](https://code.visualstudio.com/download)

### Developing New Versions
After downloading Unity Hub and Visual Studio Code, follow the below steps to make new changes to the project.

1. Clone or Fork the repository
1. Open up Unity Hub and click on "Add" then select "Add project from disk"
1. Open the cloned repository directory and select "Protect Humanity"
1. From here, the project will open up and you will be able to edit the game

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