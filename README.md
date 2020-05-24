# Game-Enginge-2-Space-Battle
C15704085 assignment for Game Engines 2 module. Unity recreation/tribute
of a Sci-Fi space battle using Unity and premade assets. My assignment involves the procedural generation
of a solar syster/ galaxy and droids in unity. A flock of these droids act as a single unity or hive, with object avoidance, facing the same direction and behaving similarly. The flock of droids follows a single large ship as it attempts to traverse a debris and asteroid field to reach a specific point, in this case a special piece of space debris
 
## Inspiration
[![](http://img.youtube.com/vi/Dmy_qUSMOWY/0.jpg)](http://www.youtube.com/watch?v=Dmy_qUSMOWY "")

Inspiration for this project came from the start of the "Suicide Mission"
from Bioware's Mass Effect 2, and is themed around the a ship trying to reach a specific point (in this instance, a space station) in the center of a debris/ asteroid field. It must do this while being chased and shot at, by smaller droids.

## Feature Aims
- [x] Select Assets
- [X] Procedurally Spawned Solar System
- [X] Procedurally Spawned Asteroids
- [X] Procedurally Spawned Droids
- [X] Fleeing Big Ship
- [X] Flocking drones
- [X] Drones chase big Ship
- [X] Object Avoidance
- [ ] Drones Shoot at Big Ship
- [ ] Ship explodes after it takes sufficient damage

## Demo Video
[![](http://img.youtube.com/vi/yreNqn6igbI/0.jpg)](http://www.youtube.com/watch?v=yreNqn6igbI "Demo")

## How it works
### Space generation 
All objects in the scene except for the the main ship and a space object, is procedurally generated. 
This was done by instantiating the objects in random positions in a sphere (of varying radii) around a central point.
In some instances, mainly asteroids, planets etc. objects are also selected randomly from an array and also have their 
rotation and scale adjusted randomly to give even greater variety in appearances. 

### Droid AI 
Once the droids are instantiated they are added to a parent "flock". This flock applies a composite behaviour, consisting of cohesion (moving together as one object, with a list of droids being iterated through with the appropriate behaviour applied to each droid), avoidance (using raycasts to determine nearby objects) and alignment ( facing the same direction, if the droid has a neighbouring droid object they are added to a list, which is iterated through implementing the same behaviour on each droid to face in the direction of the flock). These scripts had a behaviour object created from them and combined in a composite behavour, which was applied to the flock

### Main Ship AI 
The main ship is given an object (called space object in this case) which it then aims to reach. As it travels towards the target, raycasts are projected from the ship and if they hit a nearby object, the ship adjusts its alignment to avoid the object on its path. Once the main ship comes within a give radius of the target destination, it begins to slow down until it comes to a complete stop.

## Tutorials vs Self Code
As with any college project, some tutorials were used to complete the assignments
### Tutorials:
The flocking behaviours of the drones (alignment, cohesion and avoidance) was implemented using a
tutorial which was adapted from 2D to 3D, available here: 
https://www.youtube.com/watch?v=mjKINQigAE4&list=PL5KbKbJ6Gf99UlyIqzV1UpOzseyRn5H1d

A portion of the main ship's pathfinding, mainly object avoidance was implemented using a tutorial also, available here:
https://www.youtube.com/watch?v=TsB_6yjACDY&list=PL_eGgISVYZkfZRSzSDyG3tHNf5_DF-o5H&index=20

### Self coded:
The procedural generation of planets, galaxies, asteroids, droids and debris was all self coded, along with the main ship's 
seek behaviour for the space object. 
The rotation of the asteroids was also self coded.

### Feature I'm Proud of: 
I am rather proud of the procedural generation as the Game Engines 1 assignment relating to procedural generation seemed difficult at the time to me, it shows that I've improved since then. It also provides a nice variety to the look of this project as it's more unlikely that the same scene will be created again on subsequent instances.

## Assets
The following assets were taken from the Unity Asset store for the development of this project.

### Drone [Asset- Space Droid by Adequate]
https://assetstore.unity.com/packages/3d/vehicles/space/space-droid-32200
![Drone](https://github.com/DavidParnell95/Game-Enginge-2-Space-Battle/blob/master/Screenshot%20(39).png)

### Journeying Ship [Asset - Federation Corvette F3 by CGPitbull ]
https://assetstore.unity.com/packages/3d/vehicles/space/federation-corvette-f3-79860
![Ship](https://github.com/DavidParnell95/Game-Enginge-2-Space-Battle/blob/master/Screenshot%20(149).png)

### Asteroids, Planets and Backdrop [Asset - Vast Outer Space by Prodigious Creations]
https://assetstore.unity.com/packages/3d/environments/sci-fi/vast-outer-space-38913
![Space](https://github.com/DavidParnell95/Game-Enginge-2-Space-Battle/blob/master/Screenshot%20(42).png)

### Debris [Asset - Space_Objects by BLUEWARM Digital Mutlimedia]
https://assetstore.unity.com/packages/3d/props/space-objects-91874
![Debris](https://github.com/DavidParnell95/Game-Enginge-2-Space-Battle/blob/master/Screenshot%20(150).png)
