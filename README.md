Asset packs:


Classic 64 Asset Pack - https://craigsnedeker.itch.io/classic64-asset-library

Hospital Horror Pack - https://assetstore.unity.com/packages/3d/environments/hospital-horror-pack-44045

Urban Nightmares NYC inspired Texture Pack - https://thegasstation.itch.io/urban-nightmares-nyc-inspired-texture-pack

Concrete Texture Pack 2 - https://www.deviantart.com/agf81/art/Concrete-Texture-Pack-2-244738599

Dirty Sci-Fi Door Texture - https://www.deviantart.com/scifilicious/art/DIRTY-SCIFI-DOOR-TEXTURE-727910507

Ink - Arrow Style PNG - https://www.pngkey.com/detail/u2q8r5i1i1w7a9e6_ink-arrow-style-png/

PS1 PSX Old Interior Pack - https://crimsongcat.itch.io/ps1-old-interior-pack 

Blood Splatter Drip - https://www.onlygfx.com/8-blood-splatter-drip-png-transparent/ 

20 Grunge Arrow - https://www.onlygfx.com/20-grunge-arrow-png-transparent/ 

DK Crayon Crumble Font - https://www.fontspace.com/dk-crayon-crumble-font-f12602


Sound effects and music:


Flash light SFX - https://freesound.org/people/Nox_Sound/sounds/557505/

Subject Alpha and Beta Screams SFX https://youtu.be/BaVIxQPheak?t=25

UV Light SFX - https://youtu.be/h30DtkXMBwI?t=2

Subject Beta Sniff SFX - https://freesound.org/people/taure/sounds/369590/

Subject Gamma Warning Growl - https://www.youtube.com/watch?v=NPtyZoQrKkU

Item Pick Up SFX - https://freesound.org/people/TriqyStudio/sounds/467610/

Place Fuse SFX - https://freesound.org/people/Alayan/sounds/395541/

Lever Pull for electrical box SFX - https://freesound.org/people/A_Kuha/sounds/676412/

Door Opening SFX - https://freesound.org/people/kyles/sounds/637572/

Paper Pick up SFX - https://freesound.org/people/birdOfTheNorth/sounds/613291/

Door Closing SFX - https://freesound.org/people/saha213131/sounds/730196/

Objective Keypad Button Push SFX- https://freesound.org/people/oussamaben/sounds/697242/

Lore Room opening door SFX - https://freesound.org/people/Corruptinator/sounds/456889/

Footsteps - https://assetstore.unity.com/packages/audio/sound-fx/foley/footsteps-essentials-189879

In game Music - https://assetstore.unity.com/packages/audio/ambient/horror-sound-atmospheres-and-fx-96731

Main menu music: 'Shadows and Dust' by Scott Buckley - released under CC-BY 4.0. www.scottbuckley.com.au


Models and animations:


Alpha Model and Animations - https://www.mixamo.com/

Beta Model and Animations - https://assetstore.unity.com/packages/3d/characters/creatures/creep-horror-creature-244853

Gamma Model and Animations - https://assetstore.unity.com/packages/3d/characters/creatures/demon-horror-creature-with-weapon-247792

Elevator Building - https://sketchfab.com/3d-models/elevator-building-406ac9aa824e44399e57ce9a82256c54

Old Soviet Elevator - https://sketchfab.com/3d-models/old-soviet-elevator-b8f9098e1a304406a7556ac871bf0f41 

Abandoned Soviet office room - https://sketchfab.com/3d-models/abandoned-soviet-office-room-5a3b00c6a8914e58a6a94ef1b66961b0#download 

Basic Door KeyPad/CodeLock Free - https://sketchfab.com/3d-models/basic-door-keypadcodelock-free-3ea0ea6305ad47cbb744de5a6eab2b5e#download

Animated Industrial Door - https://sketchfab.com/3d-models/animated-industrial-door-dbcd6eb9c9424dbfbb23caf7ab2f1536#download 

Hospital Props - https://sketchfab.com/3d-models/hospital-props-69159185e7ac48e1ba6d3b657b6d68e1 

Lab Tube for P.A.L - https://sketchfab.com/3d-models/lab-tube-for-pal-ae74e0f761464bedb1a5e06635941472 

Acid Barrel Pack - https://sketchfab.com/3d-models/acid-barrel-pack-df4e8065c7984282907246d4c03f0f00 

Hospital Door Old Free - https://sketchfab.com/3d-models/hospital-door-old-free-15b147ae76ef40da9ad23831ca7225dd 

Crates And Barrels - https://sketchfab.com/3d-models/crates-and-barrels-5ae3c72285474862a89d69c2f2ad2246 

Industrial Pipes - https://sketchfab.com/3d-models/industrial-pipes-79f64d09a3cd496fb4f1ae601f5dafac

Wood Shipping Box (low poly) - https://sketchfab.com/3d-models/wood-shipping-box-low-poly-6606aaf169b74eb6908fbce1090ca248


CC Licenses:


https://creativecommons.org/licenses/by/4.0/

https://creativecommons.org/public-domain/cc0/

https://creativecommons.org/licenses/by/3.0/deed.en


Subject Alpha State Machine: 


The AI immediately goes into a chase state when the first fuse is grabbed. The flee state is triggered in contact with the raycast of the UV light, which then transitions into a patrol state. In the patrol state, it visits a random waypoint and idles when it gets there, after the idle period it patrols to a new waypoint. Alpha will chase based on line of sight when patrolling or idling, it can also chase if it hasnt been in chase for a random range (its 25-35 seconds).


Subject Beta State Machine: 


The AI begins in a roaming state that navigates to random waypoints when its in a certain range of a waypoint itll go to a different one. If a sound is loud enough, it will chase and kill the player. Otherwise, sounds that aren’t dangerously loud will cause an investigative state where it crawls to the audio source sniff the area. Then it will return to patrolling. 


Save system:


Any settings that you change will be saved to JSON and will be loaded as soon as you relaunch the game. Going to menu and back to game does not get rid of your config. 

This is the same for your progress. The following will be saved upon death or closing the game through game menu (force closing through windows does not save): 

Putting a fuse in a fuse box (any fuses grabbed will be lost).

Turning on an electrical box.

Starting section 2 (will spawn you in section 2).

Opening the hub (will spawn you in the hub).


UV Light Environment:


To create the desired invisible ink effect, we used decal projectors and a custom shader graph that took the status of the UV light as a parameter.

When the UV light is off, the alpha channel of the material is set to 0 so that the decal is not visible.

When the UV light is turned on, the decal becomes emissive and a sphere mask is placed in the middle of the screen so that any part of the decal outside the light does not glow.

For blood, a similar shader is used; however, when the UV is off, the decal remains visible and red.


Spoilers for game puzzles:


6753 is code for section 2 door

1985 is code for hub door


Bugs:

If you open pause menu while using a note you can move around.

If you havent done section 2 and you start the elevator sequence you can go into section 2.

Audio issues with monsters.

Main menu volume lower than intended.
