# Platformer

Here we will create a script that simulates the parallax effect.

## Parallax

First off, what is parallax?\
Well according to [Wikipedia](https://en.wikipedia.org/wiki/Parallax_scrolling) the parallax effect (in the article it's called parallax scrolling) is :

> A technique in computer graphics where background images move past the camera more slowly than foreground images, creating an illusion of depth in a 2D scene and adding to the sense of immersion in the virtual experience.

To put it another way. We want to make our background look like it's actually far away.\
The main way to achieve this is to make that background move slowly.\
This creates the same effect as looking into the distance on a car trip. The trees near the side of the road race by while the mountains in the distance seemingly move across your vision much slower.

This is purely asethetic for our game but if you use it correctly it is a really going to make your game look better. Let's set off to create this.

### Creating A Background

Of course we need to have a background before we can move it. We can quickly do this with our [Tile Editor](./3%20TileEditor.md) which we used a few lessons ago.\
To start create a new "Tilemap" object where we will put our background. This must be on a seperate object from our previous maps. Then we just need to make something pretty to be in our background. In this case we'll do some mountains but feel free to do you own thing.\

// Img needed

To demonstrate our effect better we should add a few more layers to this. Create another "Tilemap" object and create a slightly closer and smaller background. In the case of mountains, we'd now be making hills.\
Repeat this process one more time so that we have three layers of our background. This will make the parallax effect look much better than with a single layer.

// Img Needed

*Note*\
Make sure you position the `z` of these objects so that the smallest is in the front.

With those ready we can begin to write some code to simulate the parallax effect.

### Tracking An Object

One of the main parts of parallax is that it has to do with moving objects. This means we need to track an object and move based on it.

Of course we must start with creating a script for this. We should call it "Parallax". Open that up.\
First we need that object to track. You may jump straight to the player but this isn't what we want to do.\
Sinze parallax is purely a visual effect we actually want to track the camera. It's possible that your camera does not match your player's movement exactly (like if you are using the camera script from the [last unit](../3%20Top%20Down%20Arcade/Library/CameraFollow.cs)).\
The method is still the same, add a public `Transform` to the top of our script. Let's also add a comment reminding us to use the camera also.

```csharp
public class Parallax : Monobehaviour {

	// Make sure to track the camera
	public Transform objectToFollow;

}
```

Now our object should move based on the player. But it should actually be oppisite of the player. That makes it a little bit different.\
First we will store our current position to a variable so we can edit it. Then we change the `x` direction to the *negative* of the object we are following's `x` position.\
Then we set our position back to our position variable. That should look like this :

```csharp
void Update() {

	Vector3 nextPosition = transform.position;
	nextPosition.x = -objectToFollow.x;

	transform.position = nextPosition;

}
```

Now if you go back to your game and attach this to the furthest back backgroud object. You will see this now move oppisite to the player. This is most of the way to what we want.\
Next thing is to make this move at a slower speed.\
This can be acheived with a simple multiplication. Add a public `float` called "relativeSpeed" and then multiply our x position by that.

```csharp
public float relativeSpeed;

void Update() {

	Vector3 nextPosition = transform.position;
	nextPosition.x = -objectToFollow.x * relativeSpeed;

	transform.position = nextPosition;

}
```

Now in the editor set that variable to something between `0` and `1`. The object will now appear to move as if it is very far in the background.

#### Multiple Layers

After we've got that working on one of the layers in our background it is time to get it working with all three layers we created.\
To start, each layer will be moving at a different speed. This is just like looking out a car window. The trees seem to move very fast where as the mountains, further away, appear to be very slow.\
Add the script to each layer of the background and set the relative speed so the the backgrounds have three unique values with the closest background object's value being the closest to `1`.\
After setting each of these to track the camera you should be able to play the game and see our backgrounds nicely moving at a relative speeds to their distance from the player.

// Repeat background

## On Your Own

Here we have parallax working in the X dimension. The thing is, parallax also applies to the Y dimension. We won't go over that here though. But if your platformer will have a lot of verticality you may want to implement this.\
The method for this will be almost the exact same so go ahead and try it out!

Another great thing to note is that by setting the relative speed of an object above `1` the object will appear to zoom by faster than the player is moving.\
We can use this to make things appear closer to the camera than the player. For instance, if your player was supposed to be really fast you might want to have some trees that zoom past in front of the player. This can really enhance the look of the game, just make sure they don't block the camera.