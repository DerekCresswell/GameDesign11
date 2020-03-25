# Platformer

Here we will create a script that simulates the parallax effect.

## Parallax

First off, what is parallax?\
Well according to [Wikipedia](https://en.wikipedia.org/wiki/Parallax_scrolling) the parallax effect (in the article it's called parallax scrolling) is :

> a technique in computer graphics where background images move past the camera more slowly than foreground images, creating an illusion of depth in a 2D scene and adding to the sense of immersion in the virtual experience.

To put it another way. We want to make our background look like it's actually far away.\
The main way to achieve this is to make that background move slowly.\
This creates the same effect as looking into the distance on a car trip. The trees near the side of the road race by while the mountains in the distance seemingly move across your vision much slower.

This is purely asethetic for our game but if you use it correctly it is a really going to make your game look better. Let's set off to create this.

// Create world mountatins first

### Tracking An Object

One of the main parts of parallax is that it has to do with moving objects. This means we need to track an object and move based on it.

Of course we must start with creating a script for this. We should call it "Parallax". Open that up.\
First we need that object to track. You may jump straight to the player but this isn't what we want to do.\
Sinze parallax is purely a visual effect we actually want to track the camera. It's possible that your camera does not match your player's movement exactly (like if you are using the camera script from the [last unit](../3%20Top%20Down%20Arcade/Library/CameraFollow.cs)).\
The method is still the same, add a public `GameObject` to the top of our script. Let's also add a comment reminding us to use the camera also.

```csharp
public class Parallax : Monobehaviour {

	// Make sure to track the camera
	public GameObject objectToFollow;

}
```

Now our object should move based on the player. But it should actually be oppisite of the player. That makes it a little bit different.\
We are actually going to have to move based on the difference in the objects movement. To do this we need to know where the object was last frame. We should store that data now.

```csharp
public Vector3 lastObjectPosition;

void Update() {

	lastObjectPosition = objectToFollow.position;

}
```

As we move forward, this must be kept as the last thing in the `Update` function.

// Mention tracking a holder rather then individual objects