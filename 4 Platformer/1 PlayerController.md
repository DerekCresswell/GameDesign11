# Platformer

Here we will talk about using a player controller to move our player around the scene.

## Using the PlayerController

Lucky for you we will be using a premade controller for the platformer. This controller will deal with all the physics of moving, jumping, and more. We still need to capture input and hook this up to other scripts like a health script or animations.

Let's go through the basics of setting up an input controller for our script.

### Object Setup

First things first, drag the ["PlayerController"](./Library/PlayerController.cs) script into your s cripts folder (or just copy the contents and make sure to name the file exactly the same).\

// Need to add sprite

Now create a new object for your player. Put the `PlayerController` script on this object.\
At the top of the `PlayerController` script you will see there are a few requirements.

```csharp
 * Ensure you attach this to an object with a 
 * Rigidbody2D, a "head" Collider2D, a "foot"
 * Collider2D, and a childed empty object at the
 * bottom of the main objects feet.
```

To start, give this a object a "Rigidbody2D" to start. You can leave the default settings as is now.\
Next we need a "head" collider. This is simply a collider to cover the top half of the object. This can be whatever collider fits best, a box, circle, or capsule, as long as it's 2D.\
Use the "Edit Collider" button to change and shift this into position. Obviously it depends on what sprite you will be using but it will likely look something like this :

// IMG

Now we need to do the same with the "feet". You can simply add this collider to the same object and then set up the size to be correct.\
There is an important note here. You really should use a circle or capsule collider for this and **not** a box collider.\
This is because have the sharp corners of a box can limit the movement of your player by getting caught on edges or being unable to climb slopes.\
Do not worry if there is a little bit of your sprite not covered by the colliders, it will not make a noticable difference.\
Your colliders may look something like this :

// IMG

That takes care of the colliders but there is one more bit to set up. The last part from the instructions of this controller say `a childed empty object at the bottom of the main objects feet.` so let's add that.\
The code here needs to know where the players feet are. Create a new empty game object and child it to the player. Then take this and position it right in the middle of feet.\
Something like this :

// IMG

Awesome, with that all on the player we can hook it up to the `PlayerController` now.\
Now we can hook this into our controller.

* Put the Rigidbody into it's slot.
* Put the childed empty object into the spot labeled `groundCheckPoint`.
* Finally put the "head" collider into the spot labeled `crouchDisableCollider`.

There is one more setting we need to set, `whatIsGround`. This is a layer that tells us what is considered the ground in the game. For this we will create a new layer called "GroundLayer" and assign it to anything you want the player to stand on.\
We can do this by creating a new sprite called "Ground" and give it a temporary sprite and ["BoxCollider2D"](https://docs.unity3d.com/Manual/class-BoxCollider2D.html). Then go to the top of the inspector window where it says "Layer" and click it.

// IMG

Here we will simply click "Add Layer" and then call it "GroundLayer". Make sure you set every ground object to be on this layer. You do that by clicking the layer dropdown and clicking on "GroundLayer".\
Now we can go back to the `PlayerController` script and on the `whatIsGround` variable we can select the new "GroundLayer".

With that all set up we can begin to create a script that captures input to move this controller.