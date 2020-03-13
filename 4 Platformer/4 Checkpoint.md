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