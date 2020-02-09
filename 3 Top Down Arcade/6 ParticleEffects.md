# Top Down Arcade

Not only should our game play good but it should also look good! Let's talk about ["Particle Effects"](https://docs.unity3d.com/Manual/ParticleSystems.html) and add some eye catching elements to our game.

## Particle Effects

We will be using particle effects to create a little explosion when our bullets hit something.

To start right click on the hierarchy, scroll down to "Effects" and create a new "Particle System". Immediatly you will see some particles flying through the scene. That's it, you're done!\
Alright kidding, we gotta do some customizing.\
You will see a massive list of options in the inspector, we can't cover everything here but you can find info on every piece in the [Unity Manual](https://docs.unity3d.com/Manual/). Here we will focus on a few ones to create a basic explosion because explosions are cool.

Let's go through top to bottom and setup a cool explosion.\
Throughout please remember, you do **not** have to follow the settings verbatim. Please go off the beaten path and make it look good to you. You can hover over the names of settings to get a little description.

### Particle System

Here's what we will edit to make an explosion :

* Duration. we'll need to set this relatively low. In the area of `0.1` to `0.3`. This effects how long the system emits particles for.

* Looping, seeing as our explosion will happen once, uncheck this. This determines if the system loops.

* Start Lifetime, on the right of the box you will see a little arrow, click it and select "Random Between Two Constants". This allows us to have random variation in our particles which will make it more natural. These values should be quite low for an explosion, `0.3` to `0.6`.
This controls how long a particle is "alive" for.

* Start Speed, again set to "Random Between Two Constants". These values should be larger because explosions tend to be fast, `3` to `7`. This controls how fast our particles spew out.

* Start Size, set to random between about `0.5` and `1.5`. This controls how big a particle is to start.

* Start Color, you can set this if you'd like but we'll be overriding it later. This sets the starting color of particles.

* Play On Awake, Make sure this is ticked. This makes the particle start when it is created in the scene (kind of like running in the `Start` function).

* Stop Action, set this to "Destroy". This will get rid of our particle system when it finishes.

![ParticleSystem](Images/ParticleSystem.JPG);

### Emission

* Rate Over Time, set this to around `10`. This will make a little a few extra particles spill out after the intial burst. This controls how many particles are emitted per second.

* Bursts, add in a burst with the plus sign. The defaults should be good here except the "Count". We've lowered it here because our bullets are small and wouldn't produce too much debris.

![Emission](Images/Emision.JPG)

### Shape

* Shape, change this to "Circle". This controls the shape in which our particles can spawn.

* Radius, Decrease this to be closer to the size of the bullet. This controls the size of the circle.

* Rotation, set the X rotation to `90` so that our circle will be facing the right direction.

* Randomize Position, set this to a small-ish number like `0.5`. This will make our particles have a varied spawn position and will be more natural.

![Shape](Images/Shape.JPG)