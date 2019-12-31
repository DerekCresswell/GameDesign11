# Top Down Arcade Game

This is where we will begin adding in player interaction to our game with movement and shooting.

## Capturing Inputs

Before we start writing some scripts make sure you add a scripts folder to your project.\
Put in a new script and let's call it "PlayerMovement". Then open that up.

Unity has a very convient way for us to get input with the ["Input Class"](https://docs.unity3d.com/ScriptReference/Input.html). On this class there are two main functions we want. ["GetAxis"](https://docs.unity3d.com/ScriptReference/Input.GetAxis.html) for movement and ["GetButton"](https://docs.unity3d.com/ScriptReference/Input.GetButton.html) for button presses.\
To use these we simply need to call the function from the `Input` class (just like `Debug.Log`). In the case of `GetAxis` we pass in a `string` of which axis we want to get. For us, the ones we'll use are `"Horizontal"` and `"Vertical"` which by default tell us if the player is pressing "WASD" or the arrow keys.\
For `GetButton`, which we'll use a bit later, we pass in a button name and the function will tell us whether or not that button is pressed.

## Player Movemnt

To start let's make sure we know how to use the `Input` class. We will start by just printing out our key press then modify it to actually move our player.

### Printing Movement

So in our PlayerMovement script let's simply print out the horizontal axis to start.\
In our `Update` function let's add the following.

// Should this be fixed update??

```csharp
// Update is called once per frame
void Update() {

	float hAxis = Input.GetAxis("Horizontal");
	Debug.Log(hAxis);

}
```

Here we've stored the value returned from `GetAxis` to a `float` called `hAxis`. The `GetAxis` function returns a `float` and more specifically a number between -1 and 1.\
This is to inform us of the magnitude of input as well as direction. What we mainly care about is the direction because without using a joystick our key presses don't have a "half pushed" mode, they are simply down or up.\
The direction is refrencing the grid used by Unity for transformations. Basically meaning the sign of `GetAxis` (positive or negative) releates to the grid in Unity where positive horizontal axis means moving right on the grid.

// Graphic

Now to test that code we've writen.\
First save the script and return to Unity. Go to your "Player" prefab and add the "PlayerMovement" script to it. Then run the game and watch the console as you press A and D or Left and Right arrow keys.\
Hopefully this should illustrate how the `GetAxis` function works. Please try to change that code to show the vertical axis too and try that out.

### Moving The Player

Now we can actually use our input to move our player object around the game world.

First let's think of how we can do this.\
Our player's position in the game is based on the objects Transform component. If we change the values within the position section we can move the player.\
So how do we change these values within our script? Pretty simple.

In our script let's start by storing the vertical and horizontal axis values.

```csharp
// Update is called once per frame
void Update() {

	float hAxis = Input.GetAxis("Horizontal");
	float vAxis = Input.GetAxis("Vertical");

}
```

Now let's setup the actual values for movement we will move.\
This needs to be a ["Vector3"](https://docs.unity3d.com/ScriptReference/Vector3.html) because that is what `transform.position` is. A `Vector3` is really just three float values that we can access as `x`, `y`, and `z`.\
Add the following code :

```csharp
// Update is called once per frame
void Update() {

	float hAxis = Input.GetAxis("Horizontal");
	float vAxis = Input.GetAxis("Vertical");

	Vector3 movement = new Vector3(hAxis, vAxis, 0);

}
```

Now this may look a little funky at first but it's really quite simple.

* We declare the variable `movement` as a `Vector3` just like you would with any other variable. Only difference is that we are using `Vector3` rather than, say, `int`.
* Next we set it equal to a `new Vector3()`. We use the `new` keyword here because `Vector3` is a class. Don't worry too much about the techincalities of this. We then call `Vector3()` with brackets almost like it's a function. We are actually "constructing" a new `Vector3`.
* Inside the paranthesies we need to give our `Vector3` three `floats` to correspond to it's `x`, `y`, and `z` values.
* We've passed in the `hAxis` to the `x` value and the `vAxis` to the `y` value. On our grid x will correspond to horizontal movement and y to vertical.
* Finally we've set the `z` value to `0` because we don't want our character to move on the z-axis. The value still needs to be present because our game is always 3D even if we aren't using it as such.

Next we need to add this `movement` value to our player's position.\
Note saying we need to add them. This is because we need to move based on our current location.

First we need to actually access our position. This is really easy as all we have to write is `transform.position`. Then we just add it and use the shorthand of `+=` like `transform.position += movement;`.

After all that you should have something like this :

```csharp
// Update is called once per frame
void Update() {

	float hAxis = Input.GetAxis("Horizontal");
	float vAxis = Input.GetAxis("Vertical");

	Vector3 movement = new Vector3(hAxis, vAxis, 0);
	transform.position += movement;

}
```

Every frame our game will check to see if we are pressing any keys correspoinding to movement. Then it will create a new `Vector3` with these values and add that to our position in effect, moving our player.\
Let's go and test this out.

// Gif

Now we'll likely need to adjust that speed. First we will set this up and then make it editable from Unity rather than our text editor.\
To start we know that we are adding a number between -1 and 1 to our movement vector. Because of this we can declare a max speed and use the value from our axis to give us a ratio of that max speed.\
Start by adding in a new `float` and call it `maxSpeed` or similar. We then want to mulitple our axis value by that variable.

```csharp
// Update is called once per frame
void Update() {

	float maxSpeed = 1;

	float hAxis = Input.GetAxis("Horizontal");
	float vAxis = Input.GetAxis("Vertical");

	Vector3 movement = new Vector3(hAxis * maxSpeed, vAxis * maxSpeed, 0);
	transform.position += movement;

}
```

Obviously setting `maxSpeed` to `1` does nothing to our speed. You could open your script and change this to a different value but there is a better way.\
So far we've only worked inside the `Update` and `Start` function but if you look up you'll see that these are inside a class named after the file. One very useful part of this class is that we can declare a variable outside of functions and set the value of that variable in Unity.\
To start move the declaration of `maxSpeed` out of the update function but still within the class, in this case called `PlayerMovement`. It doesn't matter where about you place this but to make your file look nice and remain readable variable are typically the first thing in a class. Like so :

```csharp
public class PlayerMovement : MonoBehaviour {

	float maxSpeed = 1;

	// Update is called once per frame
	void Update() {

		float hAxis = Input.GetAxis("Horizontal");
		float vAxis = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(hAxis * maxSpeed, vAxis * maxSpeed, 0);
		transform.position += movement;

	}
}
```

Now this will still work but we can't change the value of `maxSpeed` with Unity yet. To do this we need to make the variable ["public"](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/public). We just need to put `public` in front of the variable. Like :

```csharp
public float maxSpeed = 1;
```

Now save that and return to Unity. Click on your Player object and and under the PlayerMovement script you should see an option for "maxSpeed". Try setting this value and playing the game!\
Now a fun thing you can try to illustrate the usefulness of this `public` keyword would be to put a second Player prefab into your game and give the second one a different `maxSpeed` value to the first.\
When you play the game you can see that even though these two objects use the same script they can have different values. This means that, just like prefabs, we can make one script and use it as many times as we like. Also using `public` speeds testing up ten fold. It's also good to note that anything you can turn into a variable can be `public`. Use it whenever you want to quickly alter values.

###