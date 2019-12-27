# Top Down Arcade Game

Here we will explore the concept and utilisation of prefabs in Unity.

## What Are Prefabs?

["Prefabs"](https://docs.unity3d.com/Manual/Prefabs.html) are a blueprint or default of an object that we can copy and paste around our game.\
Let's explain it with an example.\
You are adding enemies to your game. This enemy is made of a few parts :

* Enemies have a sprite renderer.
* They have scripts that deal with movement, attacking, and health.
* They have a collider.
* They have a rigidbody.
* And the list goes on.

Now if you were to start adding these enemies you can see how long it will take you. For each enemy you add you will have to add all of these things and also set the values of each component.\
Now enters the prefab.\
You make a single enemy with all the bells and whistles, turn it into a prefab, and then you can place down as many enemy prefabs as you want and all these defaults are already set.

That should illustrate how great prefabs are and also how essential they are.\
So how do we make a prefab?

## How To Make Prefabs

While first we need to create an object that we will make into a prefab. At this point you just need to try and make one, it does not need a purpose in your project here.\
You can put whatever you want onto this object. Perhaps make a "Ball" object that has a sprite (look up a ball sprite online or use the circle from the [Rube Goldberg](../1%20Rube%20Goldberg%20Machine/Assets/WhiteCircle.png)), a circle collider, and rigidbody 2D.

// Add image

For best practice, first create a new folder in your project window and name it "Prefabs". Then drag the object into that folder.
Once we have that all set up to our liking all we have to do is drag the object from our hierarchy into our project window, and more specifically with into our prefabs folder.\
It's that easy. You'll now see our object was turned into a prefab inside the folder. Now we can use that in our scene instead of making new objects.

## Using Prefabs

// Making into instances
// Updating prefabs
// Checkover and fill out extra info in this file.
