# winter2025-rpg

Link to living document google doc:
https://docs.google.com/document/d/1jnsrercgkttsRrWxbyvnjN-BLG5NbcPtNfWLKqPxTyk/edit?tab=t.0#heading=h.npvd45gblryb

Link to Trello:
https://trello.com/b/aRKvqJ4l/pt-2-group-2

### How to run the System
* 1. Navigate to the "installations" folder in the github repository 
* 2. Download the zip file for your respective operating system 

* Mac download: 

* 3. Click on the "Protect Humanity" application to open the game
* 4. Click the "start" button to begin playing the game
    * For additional information on controls, press the "controls" button to learn more

* Windows download: 


## Testing
* 1. To test the primary features, use "WASD" to move your character around the map
* 2. Using the specified movement keys, navigate toward your first item
    * When in range of your first item, you'll have a pop-up message appear saying "press E to interact"
* 3. Once you've picked up your first item, roam the map until you encounter your first enemy
    * When you collide with an enemy, an encounter pop-up will appear with the options to "start" or "run"
    * Click "start" to engage in combat
* 4. Run through an iteration of combat making sure to utilize all of the available combat features to defeat the enemy
* 5. Once an enemy is defeated, you're returned to the main scene where you can exit the application 


### Operational use cases

## Use case 1: Player movement
* User is able to move the player model around using "WASD"

## Use case 2: Enter a battle
* User is able to "encounter" an enemy and choose whether or not they'd like to battle the monster
* There are two options listed: "start" and "run"
    * "start" will send the player into the combat scene
    * "run" will close the encounter UI and returns the player to the main scene

## Use case 3: Battle option: Defend
* During combat, user is able to select the "defend" option to take reduced damage from the enemy

## Use case 4: Defeating an enemy
* When the user successfully defeats an enemy (by reducing enemy HP to 0), the user is sent back to the main scene

## Use case 5: Pick up an item
* User is able to pick up an item which is stored in the inventory by pressing "E" when an item is in range

## Use case 6: Player Defeat
* When user HP reaches 0 (after both human and robot is defeated), a message is printed stating "you have been defeated"
* After message is printed, user is returned to the main menu

### Non-operational use cases

## Use case 7: Levelling up
* User experience and level up system has yet to be implemented


### How to Build and Test the System

## For WINDOWS
* 1. Download or clone the github repository containing the project
* 2. Install Unity for Windows or MacOS
* 3. Click on "File" in the top left of your screen
* 4. Click on "Build Profiles"
* 5. Click on "Player settings"
* 6. Click the drop down menu for Resolution and Presentation 
* 7. Change Fullscreen mode to "Maximized Window"
* 8. Click "Build" 
* 9. Navigate to the "installations" folder in the github repo
* 10. Choose source destination to download file to and name it "WindowsTestbuild"
* 11. A pop-up should appear saying "missing project ID do you want to continue" press "yes"
* 12. Navigate to the folder you stored the build in and run the executable file by clicking the "protect humanity" application

## For MacOS
* 1. Download or clone the github repository containing the project
* 2. Install Unity for Windows or MacOS 
* 3. Click on "File" in the top left of your screen
* 4. Click on "Build Profiles"
* 5. Click "Build" 
* 6. Navigate to the "installations" folder in the github repo
* 7. In the "installations" folder navigate to the "Mac" folder and name your download "MacTestbuild"
* 8. A pop-up should appear saying "missing project ID do you want to continue" press "yes"
* 9. Navigate to the folder you stored the build in and run the executable file by clicking the "protect humanity" application





