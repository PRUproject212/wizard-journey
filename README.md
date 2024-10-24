Course Project: The Wizard Journey
Members
We are: 
Thai Dinh Chinh - DE170147
Huynh Ngoc Bao Khanh - DE170163
Phung Vu An Quan - DE170262

Story
The Wizard Journey follows the adventure of a wizard travelling through a mystical forest. The player's goal is to help the wizard collect magical items scattered throughout the forest. These items are crucial for unlocking access to new areas and progressing to the next levels. Along the way, the wizard must overcome various challenges and obstacles. The game emphasizes exploration and strategic collection of items to complete the journey.

Sprites
Sprite 1

This is the sprite for the main character, a little wizard
Sprite 2
	
		This is the sprite for enemy 1, green slime
Sprite 3

		This is the sprite for enemy 2, orange slime
Sprite 4

		This sprite is for enemy 3, chainsaw. This enemy cannot be destroyed.
Sprite 5

		These sprites are used to create map layers using TileMap
Sprite 6


	These sprites are items that the wizard - the main character, needs to collect to get to the next level before reaching the treasure.
Sprite 7

		This sprite is the treasure, which marks the finish of the wizard's journey
Game development: Requirements
Input from the keyboard for controlling direction and acting
- The player moves the wizard by using left and right arrows.
- Jumping using Space from the keyboard. 


There must be the end of the game (game over)
- The player loses 1 life when touching an enemy or falling on a spike.

- The game ends when the player’s life count drops to 0, and shows the Game Over screen.



There must be animations and collisions:
- The wizard has animations when moving, jumping, falling or dying.

- Use Collider to handle collisions between characters, layouts, and items in the middle of the match.

There must be an illustration of the points
- Shows the score on the screen and updates the score when the player collects gold coins

		
Sound:
- Adds sounds for actions such as jumping, moving, eating gold coins, colliding with enemies, falling, and dying.
C# Script:
- All code for the game uses C#.

Different Scenes:
- One main scene is for gameplay, and one is for the Game Over screen.

- Multiple scenes can be added for different levels.


Differential Level Change: Developing feature
- The number of items and enemies will increase, move faster and become harder to see as the game continues.
- Change the rate of enemy surprise appearances.
Random Promotions: Developing feature
- Sometimes promotional items or messages appear, such as power-ups or extra lives.
Character Upgrades: Developing feature
- Players can collect bonuses to increase their speed, improve their health, or add more lives.
Character Appearance Changes: Developing feature
- Players can collect bonuses to upgrade their costumes.
Character Appearance Changes: Developing feature
- When upgrading, the wizard can change colour or add new accessories.
Create New Objects in the Game: Developing feature
- New types of enemies will appear as the game progresses.
- Special items appear for players to collect.
Create Sub-Objects in the Game: Developing feature
- Enemies can spawn small fragments when destroyed, or spawn sub-ammo.
Storage System: Developing feature
- Uses PlayerPrefs to save the player's highest score and upgrades.
- Allows the player to continue from where they left off in the previous game.
Game development: extra functions
Equipment store: Developing feature

Future works: 
Phrase 1:
Main menu 
Play Screen 1
 Character control
Phrase 2:
Play Screen 2
Game Audio
Storage system
Character interface


Appendix
1. Github: https://github.com/PRUproject212/wizard-journey.git
2. Contribution:
Thái Đình Chinh : 35%
Huỳnh Ngọc Bảo Khánh : 35%
Phùng Vũ An Quân: 30%
