# Platformer

Here we will look over creating a basic checkpoint system for our game.

## Checkpoints

Let's go over what we want our checkpoints to do.

* Have a checkpoint object that our player can activate.
* When the player dies they should respawn at the last checkpoint they activated.
* This should be able to work with any number of checkpoints.

Alright, with that in mind we can set off!

### Creating The Object

To start we want to add a new sprite to our project. You can find a simple flag pole [here](Assets/FlagPole.png). You may of course use whatever you want but it should have two distinct states.\
Once that is in your project we need to adjust the settings for the sprite. It should be as follows :

* Sprite Mode, set to "Multiple".
* Filter Mode, set to "Point".
* Compression, set to "None".

We needed to set the Sprite Mode to multiple because there are actually two flags in our one image. A red and green flag.\
This also means we need to slice our sprite with the Sprite Editor. Luckily the automatic slicing should work in this case so just open up the editor and hit slice.

Now we can setup the object. Start by dragging the red flag into the scene. Rename it to "Checkpoint".\
We also want to give it a box collider and mark it as a trigger.\
That's most of it. Time to create a custom script to handle this. Create and name a new script "Checkpoint".

### Changing The Sprite

Let's start with declaring four variables.

```csharp
public class Checkpoint : MonoBehaviour {

	public Transform spawnAt;
	public Sprite inactiveSprite;
	public Sprite activeSprite;

	bool active = false;

}
```

The first one, `spawnAt`, is going to be where we want to spawn the player. This might not be right on the flag so having this allows us to just place them nearby.\
The inactive and active sprite should be fairly self explanatory.\
Lastly, the boolean `active` is just going to give us an easy way to tell if the checkpoint has been activated.

Next we need to handle collisions. Add in the function `OnTriggerEnter2D`.\
We will inside here we want to check if we collided with the player. We can use tags just like we have before.

```csharp
void OnTriggerEnter2D(Collider2D col) {

	if(col.tag == "Player") {
		
	}

}
```

Of course this means we need have the player tagged properly.\
Place a `Debug.Log` within the if statement and double check it is working.

If we are not currently active we need to switch over. Let's start with the sprite.\
We access the sprite with through the ["Sprite Renderer"](https://docs.unity3d.com/ScriptReference/SpriteRenderer.html) as you can see from looking at the components. We want to do just that. Add the following code :

```csharp
void OnTriggerEnter2D(Collider2D col) {

	if(col.tag == "Player" && !active) {
		active = true;
		GetComponent<SpriteRenderer>().sprite = activeSprite;
	}

}
```

What we are doing here is first checking if we are not active. Then we use ["GetComponent"](https://docs.unity3d.com/ScriptReference/Component.GetComponent.html) to get the SpriteRender from our game object. We set the sprite variable to the active sprite and this updates it in game.

Head back to the game and make sure you set the sprite variables correctly on the script.\
When you collide with the flag pole it should change from red to green. Great, that's step one done.

### Setting The Spawn Point

Time to make use of that `spawnAt` variable we made.\
Go onto the flag pole and create an empty object as a child. Then position this empty object to where you want the player to spawn at. The main reason we need this is to ensure we don't spawn in the ground so a simple thing is to just drag this object up a little.

![SpawnAtTransform](Images/SpawnAtTransform.JPG)

Drag that into the variable `spawnAt` on the checkpoint.\
Now we need to actually spawn at that position when we die. We need a quick way to kil the player. You could bring in the [health scripts](../3%20Top%20Down%20Arcade/PlayerHealth.cs) from the [previous unit](../3%20Top%20Down%20Arcade/) but in this case we will cheat a bit since setting up enemies will take some time.\
Instead create a new object and give it a box collider. Make the collider really wide (using the size setting on the Box Collider 2D) and a trigger. Then place this below our world. We will use this to detect if our player fell off the map.

![BottomOfTheMapCollider](Images/BottomOfTheMapCollider.JPG)

Make a temporary "PlayerHealth" script. Add in the `OnTriggerEnter2D` function.\
Add the following code to it :

```csharp
void OnTriggerEnter2D(Collider2D col) {

	if(col.tag == "BottomOfMap") {	
		Die();
	}

}
```

Make sure to create and add that tag to the bottom collider.\
Now to quickly make the `Die` function.

```csharp
void Die() {

	transform.position = spawnPosition;

}
```

Last thing is to add in the `spawnPosition` variable. This will be a `Vector3`. We will also need set a default for this in case we never hit a checkpoint.\
That'll look like this :

```csharp
public Transform spawnPosition;

void Start() {
	spawnPosition = transform.position;
}
```

This is very simplistic because we aren't trying to build a health script right now. Still, this should accomplish what we want. If you walk off the edge you should be teleported back to where you started. We want to focus on the check points.

Go back to the checkpoint script and now we can make this functional.\
We just need to add two lines of code to the `OnTriggerEnter2D` function.

```csharp
void OnTriggerEnter2D(Collider2D col) {

	if(col.tag == "Player" && !active) {

		active = true;
		GetComponent<SpriteRenderer>().sprite = activeSprite;

		PlayerHealth pHealth = col.gameObject.GetComponent<PlayerHealth>();
		pHealth.spawnPosition = spawnAt.position;

	}

}
```

In the first new line we create a variable that has the type of `PlayerHealth`. This is then set equal to the `PlayerHealth` script that is on our player. We need to use `GetComponent` because the script is a component of the game object.\
Then using this variable we can set the `spawnPosition` variable to the position we declared in the collider.\
Now we should be able to run into the checkpoint, die, and spawn back at the checkpoint.

We will likely need more than one checkpoint so you should turn this one into a prefab. Just drag it from the hierarchy into a new folder called "Prefabs".\
You can now add as many of these checkpoints as you want to the game. Try it out!

### Checkpoint Manager

As of now a checkpoint can only be activated once. This is fine if your game was linear and you'd just hit these checkpoints one after another.\
Now if you wanted a more free form approach we would have to make some changes. Let's do that now.