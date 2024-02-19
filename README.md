# Retribution-The-first-encounter

## Vision
I hope to create a fast paced bullet hell experience which shows off good software design and architecture.

The theme of the is supposed to be good vs evil. With the game having some story elements that follow this basic principle.
The visual and sound aspect will be neglected for the most part as it will be too time cosuming to do along with other elements for now.
All values of the game are controlled by a script that can be edited easily, and the changes are applied when the game is next started.

Keyboard inputs are also able to be set by the player in a configuration UI.

## Gamplay Loop
The gameplay loop will be a relatively simple formula, following other staples of the Bullethell genre. You will have simple waves where you battle weak enemies which aim to let you power up.
After defeating an enemy, they will drop a item that will contribute to the players overall stats, with the game also increasing its difficulty based on the time spent in game.
After half a minute to a minute, the first boss will spawn. This boss will be high in HP, but still defeatable by the player. If the player manages to defeat the boss he will gain a unique powerup that the boss had applied to his attacks, in essence granting you his unique ability.
After the boss phase, the next basic phase will begin to prepare you for the final boss, the main goal being to defeat weak enemies to gain power for the final boss.
The final boss will be a high HP target which has both minions and support turrets to help him. Defeating these during the boss phase will spawn powerups, they should be needed to deafeat the boss. 
You will not be strong enough to defeat him when the battle starts.

## Details

### Player Stats:
Info: Dies in one hit, unless invincibility is active
Lives: 
- Easy: 9
- Normal: 6
- Hard : 3
Damage: Scales with upgrades, base 5
Fire rate: Scales with upgrades, base 5 per seconds
Projectiles: move fast, are small. Scale with upgrades.

### Phase 1:
Spawn ads: Weak enemies that shoot slow projectiles
Amount: Varies based on how fast player defeats them
Enemy projectiles: Vary based on enemy type. Have unique look based on behavior.
Timeout: 45 seconds.

### Boss 1:
No ads: The first boss will not have support from ads.
Effect: The boss will have a unique upgrade that effects his attack pattern for the battle.
Health: 1,000
Timeout: 60 seconds, can be faster if killed quick.

### Phase 2:
Spawn ads: The enemies from phase 1 return and have scaled their stats in accordance with the player.
Amount: Varies on how fast the player is able to eliminate them
Enemy Projectiles: Carried over from phase 1, but move faster.
Timeout: 45 seconds

### Final Boss:
Ads: Ads will spawn with the final boss, along with stationary turrets that will shoot bullets in static places, easy to dodge when alone but difficult in mass
Attack Pattern: Planned is to make the boss shoot a circle of projectiles, in combination with projectiles that have alternating paths.
Health: 20,000

### End:
The game will display some story element, and thank the player for beating the game.