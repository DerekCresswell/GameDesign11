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