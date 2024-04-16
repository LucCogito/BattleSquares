**Genre:** 2D top-down bullet hell.  
 **Platform:** Browser.  
 **Engine:** Unity.  
 
 ## Introduction
 **Presentation:** Game should force 16:9 ratio, thus UI can be designed for a 1920x1080 resolution.

 All ability types with their projectiles shown below and player next to them:  
 ![ConceptGraphic1](DesignGraphicAbilities.jpg)

 All normal enemy types facing down with abilities dropped by them shown below:  
 ![ConceptGraphic1](DesignGraphicEnemies.jpg)

Final boss and its projectile:  
![ConceptGraphic1](DesignGraphicBoss.jpg)

 Square abilites: 
 1. Every 0.2s shoot a bullet, knocking you back slightly in the process
 2. Every 1s shoot 3 bullets at once in a shotgun pattern
 3. Every 1.5s Dash towards aiming direction damaging and knocking back all enemies in your way
 4. Every 3s throw a short ranged boomerang that deals damage to hit enemies both when going away and towards the player

 Enemies:
 * Circle (0min, 14) - Moves directly towards player with steady velocity
 * Hexagon (2min, 13) - Pulses towards future player position every 0.3s with medium-high speed
 * T-shape (4min, 24) - Moves to a random position, then shoots at player once and repeats
 * X-shape (6min, 12) - Slow speed. Pursues player position from one point in the past (saves old player position to have it ready for next pursue)
 * U-shape (8min, 23) - Low turning speed. Quickly moves towards player position offset by a random vector. After reaching it rolls a new offset vector
 6. Star boss - Slowly follows player while shooting projectiles from all 5 arms in appropriate directions

 ## Gameplay