# John Lemon Project

## Dot Product
Improve enemy detection by using a 45 degree cone instead of an oblong collider. Makes it more realistic like a cone of vision. Triggers whenever player enters enemy's cone of vision. Walls will hide player from cone of vision.
 
## Linear Interpolation
The player's stopping motion is dampened instead of stopping abruptly. Anytime the player stops moving, the lerping takes effect. There is a small issue when the player stops input then immediately tries walking again where John begins sliding. That's due to the lerping adding velocity to the rigidbody and the player not giving it enough time to zero out.

## Particle System
A dust particle system has been added throughout the house. The dust particles are born anywhere between the camera and player, adding to the top-down perspective. They're constant without input from the player.

## Contributions
I am the sole developer.