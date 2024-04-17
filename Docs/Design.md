**Genre:** 2D top-down bullet hell.  
 **Platform:** Browser.  
 **Engine:** Unity.  
 **Presentation:** Game should force 16:9 ratio, thus UI can be designed for a 1920x1080 resolution.

 ## **Main Menu**

![ConceptGraphic1](DesignGraphicMenu.jpg)

The shade of all buttons and audio slider should match the color of ingame entities like the player and enemies:  
* Play button - Player's green
* Upgrades button / Return button - Final Boss' purple
* Audio slider - Circle Chaser's yellow
* Rapid Fire upgrade button - Hexagon Hopper's red
* Spread Fire upgrade button - X Tactician's orange
* Dash upgrade button - U Speeder's pink
* Boomerang upgrade button - T Shooter's blue

Player can change audio volume at any time in menu and in Pause screen during gameplay, by clicking and sliding the bar under the note icon.  
Number displayed in the upper left corner shows how many points the player has. Even though the score is a floating-point number, only the integer part is visible.

Pressing the Upgrades button reveals Upgrades Menu:

![ConceptGraphic1](DesignGraphicUpgrades.jpg)

Player may press upgrade buttons to increase the tier of abilities at the cost of gathered points (up to tier 3). Doing so will add a "+" marks below upgraded ability, to indicate its new tier. With each upgrade, abilities gain bonus damage that will be added on top of the flat ability damage during gameplay according to the table: 

| Upgraded Ability | Bonus Damage per Tier | Bonus Damage at Tier 3 |
| --- | --- | --- |
| Rapid Fire | +1 | 3 |
| Spread Fire | +2 | 6 |
| Dash | +3 | 9 |
| Boomerang | +4 | 12 |

Player can press purple Return button at any time to return to Main Menu.

 ## **Gameplay**

![ConceptGraphic1](DesignGraphicGameplay.jpg)  
All ingame entities behave like floating ships, that slowly turn and propel through the space, while their movement can be disturbed by knockback.

 ### Enemies
 After pressing the start button, menu interface disappears, revealing the player square behind it. Right from the beginning, enemies spawn outside the board at intervals of 1.10 seconds, which decreases by 0.05 seconds per minute of gameplay, reaching a spawning frequency of 0.65 seconds at the 9:00 minute mark. The type of spawned enemy is randomly chosen each time according to the following percentage table:

| Minute | Circle Chaser | Hexagon Hopper | T Shooter | X Tactician | U Speeder |
| --- | --- | --- | --- | --- | --- |
| 0 | 100 | - | - | - | - |
| 1 | 100 | - | - | - | - |
| 2 | 75 | 25 | - | - | - |
| 3 | 50 | 50 | - | - | - |
| 4 | 50 | 25 | 25 | - | - |
| 5 | 34 | 33 | 33 | - | - |
| 6 | 40 | 20 | 20 | 20 | - |
| 7 | 25 | 25 | 25 | 25 | - |
| 8 | 30 | 15 | 15 | 15 | 15 |
| 9 | 20 | 20 | 20 | 20 | 20 |

Each enemy type has distinct features like speed, maneuverability (rotation speed), navigation algorithm and health which scales with game time as shown below:

| Enemy Name | Health at Minute 0 | Health per Minute | Health at Minute 9 |
| --- | --- | --- | --- |
| Circle Chaser | 3 | +3 | 30 |
| Hexagon Hopper | 6 | +4 | 42 |
| T Shooter | 7 | +3 | 34 |
| X Tactician | 10 | +5 | 55 |
| U Speeder | 2 | +2 | 20 |

* Circle Chaser
  * Speed: Medium
  * Maneuverability: Fast
  * Moves directly towards player
* Hexagon Hopper
  * Speed: Medium-Fast
  * Maneuverability: Medium
  * Hops towards future player position predicted based on their velocity
  * Switches to direct targeting when close to the player
* T Shooter
  * Speed: Medium-Slow
  * Maneuverability: Medium-Fast
  * Moves to a randomly chosen position. When reached, aims at the player and shoots one bullet, then chooses a new position to reach
* X Tactician
  * Speed: Slow
  * Maneuverability: Medium-Slow
  * Snapshots player position every 2-4 seconds. Remembers up to 3 snapshots. Moves to the chosen snapshot position. When reached, draws a snapshot from the pool of newly saved ones and moves towards it
* U Speeder
  * Speed: Fast
  * Maneuverability: Slow
  * Moves towards player position offset by a constant vector that's randomized at the start. When reached, rolls a new offset vector

When an enemy's health drops to 0, it's destroyed and has a 10% chance of dropping one of its assigned upgrades, while the player's score increases by 0.1. Each enemy type has two upgrade types it can drop:

 ![ConceptGraphic1](DesignGraphicEnemies.jpg)

 **Circle Chaser** drops *Rapid Fire* or *Boomerang*  
 **Hexagon Hopper** drops *Rapid Fire* or *Dash*  
 **T Shooter** drops *Spread Fire* or *Boomerang*  
 **X Tactician** drops *Rapid Fire* or *Spread Fire*  
 **U Speeder** drops *Spread Fire* or *Dash*

 Upon reaching minute 10:00 enemies stop spawning and the final boss is created. From now on, upon defeating all enemies (including boss) player wins the game.

 ![ConceptGraphic1](DesignGraphicBoss.jpg)  
* Health: 500
* Speed: Slow
* Maneuverability: Slow
* Moves directly towards the player while shooting projectiles outwards from all five arms every 2 seconds
* Upon defeat increases player score by 10, but drops no upgrade

### Player
To fight their foes, player can move using keyboard WSAD or Arrow keys and use abilities assigned to Left and Right Mouse Buttons. At the beginning of the game, the only skill possessed by the player is Rapid Fire at level 0 assigned to LMB. To acquire new skills or upgrade existing ones, they must move over the upgrade dropped by an enemy:  

* If acquired ability already occupies a slot -> Increase that ability's level by 1 (up to 3)
* If RMB ability slot is empty -> Equip acquired ability there and set it to level 0
* If both slots are occupied by other abilities -> Remove one of them at random and place acquired ability in its place with level set to 0

Upgrading abilities increases damage dealt by them as shown below:

| Ability Name | Damage at Level 0 | Damage per Level | Damage at Level 3 |
| --- | --- | --- | --- |
| Rapid Fire | 1 | +1 | 4 |
| Spread Fire | 2 | +2 | 8 |
| Dash | 3 | +3 | 12 |
| Boomerang | 4 | +4 | 16 |

Currently equipped abilities are displayed in the top-left corner. The number of small, white squares under ability icon indicates its level. Above them are three hearts representing player lives. Colliding with enemy or its bullet substracts one health state.  
Using abilities other than *Dash* shoots projectiles, at coursor position, that damage enemies they crash into:

![ConceptGraphic1](DesignGraphicAbilities.jpg)  
* Rapid Fire 
  * Every 0.33 second shoots a cylinder projectile that slightly knocks back the player
* Spread Fire 
  * Every 1.2 seconds shoots three circular projectiles in a 90 degree cone
* Dash 
  * Every 1.6 seconds dashes towards aiming direction damaging and knocking back all enemies in the way
* Boomerang 
  * Every 2.5 seconds shoots a crescent projectile that passes through enemies and returns to the player

Player can access Pause screen through one of these actions:
* Pressing ESC button
  * "PAUSE" text displays above Restart button
  * Press ESC again to exit 
* Loosing all three health states
  * "DEFEAT" text displays above Restart button
* Defeating all enemies after the 10:00 minute mark
  * "VICTORY" text displays above Restart button

Displaying Pause screen sets ingame time scale to 0.  
![ConceptGraphic1](DesignGraphicPause.jpg)