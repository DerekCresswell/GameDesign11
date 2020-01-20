# Top Down Arcade Game

This is where we will begin adding in player interaction to our game with movement and shooting.

## Capturing Inputs

Before we start writing some scripts make sure you add a scripts folder to your project.\
Put in a new script and let's call it "PlayerMovement". Then open that up.

Unity has a very convient way for us to get input with the ["Input Class"](https://docs.unity3d.com/ScriptReference/Input.html). On this class there are two main functions we want. ["GetAxis"](https://docs.unity3d.com/ScriptReference/Input.GetAxis.html) for movement and ["GetButton"](https://docs.unity3d.com/ScriptReference/Input.GetButton.html) for button presses.\
To use these we simply need to call the function from the `Input` class (just like `Debug.Log`). In the case of `GetAxis` we pass in a `string` of which axis we want to get. For us, the ones we'll use are `"Horizontal"` and `"Vertical"` which by default tell us if the player is pressing "WASD" or the arrow keys.\
For `GetButton`, which we'll use a bit later, we pass in a button name and the function will tell us whether or not that button is pressed.

***Note***
The names of these axes are set through the ["Input Manager"](https://docs.unity3d.com/Manual/class-InputManager.html). You can also add new ones. We will talk more about this in a [section](#setting-up-button-inputs) later on.

## Player Movement

To start let's make sure we know how to use the `Input` class. We will start by just printing out our key press then modify it to actually move our player.

### Printing Movement

So in our PlayerMovement script let's simply print out the horizontal axis to start.\
In our `Update` function let's add the following.

// Should this be fixed update??

```csharp
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
void Update() {

	float hAxis = Input.GetAxis("Horizontal");
	float vAxis = Input.GetAxis("Vertical");

}
```

Now let's setup the actual values for movement we will move.\
This needs to be a ["Vector3"](https://docs.unity3d.com/ScriptReference/Vector3.html) because that is what `transform.position` is. A `Vector3` is really just three float values that we can access as `x`, `y`, and `z`.\
Add the following code :

```csharp
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

### Following The Player With The Camera

With our player moving it is obvious that the camera needs to follow the player otherwise we cannot see the player. There is a really simple way to do this but really only works when our player does **not** rotate.\
All we need to do is ["child"](https://docs.unity3d.com/Manual/Transforms.html) our [Camera](https://docs.unity3d.com/Manual/class-Camera.html) object to our player. This will make the transform of the camera relative to the player rather than the center of the world.\
Now we want the camera's transform to be `0` for X, `0` for Y, and a negative number for Z. This is because we want the camera centered on the player, that's the X and Y, but it needs to have a negative Z as to not be on the same plane as the player. That is to say :\
If the camera's Z is also 0 it will be at the same level as the player and cannot see it. Just like you cannot see something directly beside you.

![ChildedCamera](Images/ChildedCamera.JPG)

If you do want your player to rotate (like if you are going to use the [MouseAim script]()) you will need to add this [simple code](Library/CameraFollow.cs) to a script and place it on the camera.

```csharp
public class CameraFollow : MonoBehaviour {

	// Set this to the player in the game (NOT the prefab)
	public GameObject player;

	// Stores the difference between the player and camera
	Vector3 offset;

	void Start() {

		offset = transform.position - player.transform.position;

	}

	// Update is called once per frame
	void Update() {

		// Update the cameras position
		transform.position = player.transform.position + offset;

	}
}
```

If you use this script you must do two things.

* Do not have the camera childed to the player for this 
* Place the camera where you want it in relation to the player before you start the game.

Use the above code for now, the [version](Library/CameraFollow.cs) in the [Library](Library) is slightly more advanced to allow for a smoother feel.\
This will be what is used for the rest of these lessons, though it does not affect you very much.

## Shooting

We've got a moving player, now let's try to add a basic shooting mechanic to our game. What we are going to build here is a basic four point shooting system. What that means is we can shoot up, down, left, and right.\
This will be expandable to an eight point system (four point plus diagonals) and including in the script library will be a mouse shooting script (aim with the mouse 360 degrees around your player).\
Don't worry about that yet though, onto the basic four point system.

### Setting Up Button Inputs

First thing to do is to make a new script called "PlayerShoot". Make sure to put it into the Scripts folder. Open it up.\
Now this script will be controlled with the arrow keys by default. Which means we need to change our inputs because currently the arrow keys can move our character as well.\
This is because the arrows keys are by default to set to be in the Horizontal and Vertical axes. The same ones we used in our movement script.

We need to open up our input manager. In the top left go to "Edit", then down to "Project Settings". Once that opens click on "Input".

![ProjectSettings](Images/ProjectSettings.JPG)

This is the input manager. In here we can change which buttons correspond to which axis. We need to move the arrow keys from the Horizatonal and Vertical axis to new axes that will be for shooting.\
Click on "Horizontal" from the list of axes. Find "Negative Button" and "Positive Button" and delete their corresponding keys ("left" and "right" in this case). It's ok that those two fields are now empty because these axes have alternate keys specified.\
Do the same for the "Vertical" axis and then play your game. You will notice that the arrow keys no longer move you player but WASD do.

![RemoveArrowInput](Images/RemoveArrowInput.JPG)

With that we are good to go and can start writing a script for shooting.

### Printing Shooting

Just like with movement we are going to start simple by just detecting our key presses. Make a new script (in the scripts folder) and name it "PlayerShoot" or similar.\
In the `Update` function we need to detect our key presses similar to our movement but not exactly. We are going to use the method ["Input.GetKeyDown"](https://docs.unity3d.com/ScriptReference/Input.GetKeyDown.html) which uses the key names rather than an axis name.\
This function returns a `boolean` that is `true` if the key was pressed that frame and `false` otherwise. Because of this `boolean` we can stick the function directly into an `if` statement. Let's try printing something if the player press the key "up". Put this in the `Update` function just like before.

```csharp
void Update() {

	if(Input.GetKeyDown("left")) {
		Debug.Log("Left");
	}

}
```

Put this script onto your player and try running the game. You should be able to move with WASD and by pressing <kbd>&#8592;</kbd> the console will say "Left".\
Perfect. Now we just need to expand this to use all four arrow keys. Let's start by adding in the right arrow key. To do this add an `else if` to our current code. Then changed which key we are using and the output.

```csharp
void Update() {

	if(Input.GetKeyDown("left")) {
		Debug.Log("Left");
	} else if(Input.GetKeyDown("right")) {
		Debug.Log("Right");
	}

}
```

We want to use the `else` here because you cannot should left and right at the same time. This makes it so only one can run each frame. Go ahead and try this out.\
Next we add the <kbd>&#8593;</kbd> and <kbd>&#8595;</kbd> keys to this. We want to duplicate what we currently have so that left and right are an `if else` and up and down are a seperate `if else`.

```csharp
void Update() {

	if(Input.GetKeyDown("left")) {
		Debug.Log("Left");
	} else if(Input.GetKeyDown("right")) {
		Debug.Log("Right");
	}

	if(Input.GetKeyDown("up")) {
		Debug.Log("Up");
	} else if(Input.GetKeyDown("down")) {
		Debug.Log("Down");
	}

}
```

Now let's move on to turning this into actually shooting a bullet.

### Making A Bullet Prefab

Before we can shoot a bullet we need to make a bullet. First let's outline what we are actually about to do.\
We are going to make a bullet prefab. Then in our `PlayerShoot` script we will spawn an instance of the bullet prefab and give it a velocity. With that in mine we can make a simple bullet prefab.

* In your scene make a new sprite (just like with the player prefab) and name it "Bullet".
* Set the sprite to our [white circle sprite](../1%20Rube%20GoldBerg%20Machine/Assets/WhiteCircle.png) and give it a color if you want.
* Set the scale of this sprite (under the transform) to around `0.5` or whatever looks best in comparision to our player.
* Add a Rigidbody 2D to the bullet.
* Add a Circle Collider 2D to the bullet. Make sure the size is right.

![BulletPrefab](Images/BulletPrefab.JPG)

Once you have that, make it into a prefab by dragging it into the "Prefabs" folder we made.\
You should be able to get rid of the bullet in the scene now and just keep the prefab.

### Spawning A Bullet

Now that we have a basic bullet prefab we can start spawning it instead of just printing out a direction. Open up the `PlayerShoot` script.\
At the top of our script add in a new `public` variable of the type ["GameObject"](https://docs.unity3d.com/ScriptReference/GameObject.html). This will be used to store our bullet prefab.

```csharp
public GameObject BulletPrefab;
```
Save that and head back to Unity. If you click on the player prefab you will see the new variable under the PlayerShoot script. Drag the bullet prefab into that slot. This way when we run our game the variable `BulletPrefab` inside of the `PlayerShoot` script.\
Go back into our shooting script.\
We are now going to replace the `Debug.Log`'s inside of our `Update` function with spawning a bullet. To spawn a prefab we can use the ["Instantiate"](https://docs.unity3d.com/ScriptReference/Object.Instantiate.html) function from Unity.\
The `Instantiate` function takes three arguements. The first is the actual prefab we'd like to create. Next it needs a `Vector3` containing the XYZ coordinates of the new objects Transform. The third defines the rotation of the object as a ["Quaternion"](https://docs.unity3d.com/ScriptReference/Quaternion.html).\
Here we've omitted the other `if` statements as they are trivial.

```csharp
void Update() {
	if(Input.GetKeyDown("left")) {
		Instantiate(BulletPrefab, transform.position, Quaternion.identity);
	}
}
```
Let's break this down a little. `BulletPrefab` refers to the variable we just made which is our bullet prefab.\
`transform.position` is the position of the player. `transform` refers to the transform component on the "owner" of the script, in this case the Player. We then call `.position` to get the `Vector3` that is our player's XYZ coordinates.\
`Quaternion.identity` is a predefined constant that refers to ["no rotation"](https://docs.unity3d.com/ScriptReference/Quaternion-identity.html). You don't need to worry too much about this as it is a high level math concept. Later we can show you an easier way to adjust rotation.

Now go back to Unity and run your game.

As you press the arrow keys you will see bullets popping out of the side of your player. Hardly bullets but still a great step!\
Now we will work on two more things to make these bullets better.

#### Adding Force To Bullets

First thing about our bullets is that they are rather lame. They need to go fast and because this is top down, gravity shouldn't affect them.\
To solve the gravity issue simply open up the bullet prefab, scroll down to the Rigidbody and set [Gravity Scale](https://docs.unity3d.com/ScriptReference/Rigidbody2D-gravityScale.html) to `0`.\
This just says that gravity should not affect this object.

Next we need the bullet to shoot off into the distance.\
Open up the PlayerShoot script. Add to our script a new function called "ShootBullet". This should return `void` and take one `Vector3` as an arguement.

```csharp
void ShootBullet(Vector3 direction)
```

Now we want this function to spawn a bullet and then give it some velocity based on direction.\
Start by moving our `Instantiate` line of code from our `Update` to here. But we want to now set this equal to a variable. By doing this we hold a reference to the object we just spawned.

```csharp
void ShootBullet(Vector3 direction) {

	GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;

}
```

// Finish, check as GameObject part

#### Deleting Bullets On A Timer

### Detecting Bullet Hits

// Use tags to detect bullet hits. Delete bullet on collision