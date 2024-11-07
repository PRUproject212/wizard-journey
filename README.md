# Course Project: The Wizard Journey

## Members
We are:
- **Thai Dinh Chinh** - DE170147
- **Huynh Ngoc Bao Khanh** - DE170163
- **Phung Vu An Quan** - DE170262

## Story
*The Wizard Journey* follows the adventure of a wizard traveling through a mystical forest. The player's goal is to help the wizard collect magical items scattered throughout the forest. These items are crucial for unlocking access to new areas and progressing to the next levels. Along the way, the wizard must overcome various challenges and obstacles. The game emphasizes exploration and strategic collection of items to complete the journey.

## Sprites
1. **Main Character**: Sprite for the little wizard.
2. **Enemy 1**: Green slime.
3. **Enemy 2**: Orange slime.
4. **Enemy 3**: Chainsaw. This enemy cannot be destroyed.
5. **Map Layers**: Used to create map layers using TileMap.
6. **Collectible Items**: Items that the wizard needs to collect to proceed to the next level before reaching the treasure.
7. **Treasure**: Marks the finish of the wizard's journey.
8. **Supporter**: Sprite for the wizard's supporter.
9. **Additional Supporter**: Another supporter sprite for the main character.

## Game Development: Requirements

### Controls
- Move left/right using the **arrow keys**.
- **Jump** using the **space bar**.

### Game Over
- Player loses 1 life when touching an enemy or falling on a spike.
- Game ends when the player’s life count drops to 0, displaying the Game Over screen.

### Animations and Collisions
- The wizard has animations for movement, jumping, falling, and dying.
- Colliders handle collisions between characters, layouts, and items.

### Score Display
- Shows the score on the screen, updated when the player collects gold coins.

### Code
- Game logic is implemented in **C#**.

### Sound Effects
- Background sounds for gameplay and interface actions.
- Action sounds for jump, dash, coin collection, landing, and dying.

## Additional Features

### Character Upgrade
- Players can collect bonuses to upgrade their character by purchasing items that add extra lives or energy tanks.

### Scenes
- Main gameplay scene and Game Over screen.
- Additional scenes for different levels.

### Level Progression
- Increasing number of items and enemies as levels progress, with faster and more challenging obstacles.

### Random Events
- Occasionally generates promotional items or enemies like power-ups and darts.

### Character Customization
- Collect bonuses to upgrade costumes and character appearance.

### New Objects
- New types of enemies and special items appear as the game progresses.

### Sub-Objects
- Enemies spawn fragments or sub-ammo when destroyed.

### Storage System
- Allows the player to store game points and health.

## Extra Functions

### Equipment Store
- Players can purchase items for character upgrades.

### Web Deployment
- Play the game online.

## Development Phases

### Phase 1:
- Main menu
- Play Screen 1
- Character control

### Phase 2:
- Play Screen 2
- Game audio

### Phase 3:
- Storage system
- Character interface
- Web deployment

## Appendix
1. **GitHub**: [Repository](https://github.com/PRUproject212/wizard-journey.git)
2. **Play Link**: [The Wizard Journey on Itch.io](https://dinhchinh1304.itch.io/pruthewizardjourney)
3. **Contribution**:
   - Thai Dinh Chinh: 35%
   - Huynh Ngoc Bao Khanh: 35%
   - Phung Vu An Quan: 30%
