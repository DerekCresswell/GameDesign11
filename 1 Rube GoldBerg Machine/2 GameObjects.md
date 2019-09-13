# Rube Goldberg Machine

This is explaining the concept and implementation of "Game Objects" in Unity.

## Game Objects

A Game Object is really anything you put into your game. Everytime you see a character, camera, or piece of the land it is a Game Object. Game Objects hold a list of "Components" that act as it's settings and behaviours. 

### Creating A Game Object

Let's put a Game Object into our "Scene".

![NewGameObject](Images/NewGameObject.JPG)

Move your mouse over the "Hierarchy" on the left of your screen, right click, hover over "2D Game Object", and finally Click "Sprite".\
You will now see that there is a "New Sprite" object underneath the "Main Camera".\
Right click this and select "Rename" and give it a name like "Circle". We need to keep our objects named well otherwise it becomes very confusing to fix issues when there are tons of objects.\
We cannot yet see this Object in the Scene. Let's fix this quick.\
Click on the "New Sprite" object and look at the "Inspector" on the right side of the screen.\

![Inspector](Images/Inspector.JPG)

What we need to do to make our object visible is :

1. We need to move the object so that it is not in the center of the scene and being blocked by the "Main Camera" Object. We do this by changing the "Transform" of the Object.
	* In the top section "Transform" find the set of three numbers beside "Position" and set these to "2", "2", and "0" respectively (You can also see this in the photo below).
	* (You can also select the "Move Tool" in the top left of Unity and drag the green and red handles that appear).

1. Next we need to give this object a "Sprite" or picture to actually appear as when we look at it. We do this by giving the "Sprite Renderer" a "Sprite".

	* On the right side on the screen under the "Inspector" find the "Sprite Renderer".
	* The top setting here should be "Sprite", look to right at the bar that says "None (Sprite)". Just at the right edge there is a small circle. Click this.
	* A menu like the one shown above will appear. These are all of the Sprites in your project. For now we just have the default ones. Go ahead and select "Knob". (Later in this project we will add our own sprites.)

	![SetSprite](Images/SetSprite.JPG)

1. Now you can see the circle in the Scene View though it's very small. Let's fix this. 
	* In the "Inspector" find the Transform again.
	* This time we want to find the "Scale" property. This controls the scale of the object, unsprisingly. 
	* Now set the three numbers to "5", "5", and "1" respectively. See below.

![SetScale](Images/SetScale.JPG)

Our circle shoud be now be clearly visible in our Scene.

*A Note*
* You can use the various "Gizmos" in the top left corner to manipulate your objects. Try clicking on any of them ("Move", "Rotate", "Scale") and use the arrows / lines that appear with in the Scene View to change the respective parameter on the object.

### Saving

Unity saves things as "Scenes". This can be thought of more or less as a level in your game. When you make a new Unity project it creates a "SampleScene" for you, We are going to use our own though.\
Press "Ctrl + S" or click on "Save" under "File" in the top left corner. This should bring up your File Explorer. There will be a file there named "Scenes", double click this, change the name of your file to something like "MyScene", and hit save.\
This will create a new Scene with our Object saved in it.\
Make sure you save your project frequently!\

### Hierarchies

Here we're going to go onto a tangent to learn about hierarchies. These are a way to attach an object to another object. This way we can manipulate the "Parent" object and affect the "Child".\
Hierarchies can be very complex and very usefull but for now we will just be showing the idea behind a hierarchy.\
Start By duplicating the "Circle" we created earlier. Rename the new Object to keep everything organized. Then change it's Position to "-2", "2", "0" respectively.\
This should something like this.\

![DuplicateCircles](Images/DuplicateCircles.JPG)

We are now going to "Parent" our second Circle to the first. We can do this by clicking and dragging the "Circle2" over the "Circle" under the Hierarchy window in Unity.

![ParentedObject](Images/ParentedObject.JPG)

You will now notice that the second cirlce Object is indented below the first. You will also see an arrow beside the first ones' name that can be used to toggle the view of its Children.\
Now I'd like you to try moving the first Circle around the Scene. Notice how the second one moves. Its position is based on the the first ones position.\
Let's go over what we have here : 
* A "Parent" is any Object with Children. The Parent acts as the base for it's Children.
* A "Child" is any Object with a Parent. The Child will inherit properties from it's Parents. In our case, it's position.
* You can have multiple levels in your Hierarchy. As in a Child itself can have a child.

Feel free to take a some time right now to just play around with what we have. Try rotating your circles, or scaling them differently. You could even add more Objects. Just have some fun and get a feel for this.

### Components

Now we are going to talk about components.\
Components allow us to add more functionality to our Objects. Our circle already has a few components on it, "Transform", and "Sprite Renderer". Both of these add something to the object. "Transform" lets the Object have a position in our scene and the "Sprite Renderer" lets the Object display a sprite.\
There are tons of built in Components in Unity and later on we will make our own.\
Let's add a "Rigidbody" Component to our Circle. This Component will add the functionality of being affected by physics, like gravity.\
Select your Circle and click "Add Component" in the Inspector. Start typing "Rigidbody" and when the option pops up choose "Rigidbody 2D" (2D is very important here as our project is going to be 2D).\

![AddComponent](Images/AddComponent.JPG)

For simplicity sake I will "Detach" the second Circle from our First. To do this click and drag the "Circle2" in the Hierarchy and move it off of "Circle". You can tell it is not a parent because the name will no longer be indented below "Circle".\
Go ahead and press Play now. This will show us the "Game View" or what is actually happening when someone were to play our game.\
The Rigidbody we added to the circle makes it affected by gravity and falls off the screen. We will talk more about the Rigidbody in the next lesson.\

As you can see Components let us have functionality wrapped into a nice clean package. It also allows use to reuse and have better control when making changes.
