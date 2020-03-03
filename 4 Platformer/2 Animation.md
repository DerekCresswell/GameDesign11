# Platformer

Here we will discuss how to make and use animations in Unity.

## Unity's Animation System

Unity has a **very** powerful [animation system](https://docs.unity3d.com/Manual/AnimationOverview.html). We could very easily get lost within this so we will have to focus down on a small part of it that we will start to use.

First let us talk about the type of animation we will be doing. Sprite based animations, or sprite sheet animation, think the original Super Mario. This is opposed to rigging based, think a Call Of Duty character.\
Sprite sheet animation is where we have basically a list of pics each defining a frame of the animation, or a pose. Checkout the image below :

![MarioRun](Images/MarioRun.JPG)

You can see each frame is a distinct point in Mario's run animation. We can then put these one after another to create an animation for our character.

Unity's animation system is split into two main parts, [animations](https://docs.unity3d.com/Manual/AnimationClips.html) (also refered to as animation clips) and [animation controllers](https://docs.unity3d.com/Manual/AnimatorControllers.html). We will get more into this later. Let's start by creating a walking animation for our object.

### Splitting Sprite Sheets

For this project we will be using [this sprite sheet](Assets/SoliderSpriteSheet.png). Drag that into your sprites folder.\
The first thing we need to do is split up this sheet into individual sprites.\
Click on the image in your project and in the inspector change "Sprite Mode" from "Single" to "Multiple". Hit apply and then click "Sprite Editor".

Here we need to split up our sprite. At the top you will see a button that says split. When you click on it there will be a drop down. It should start with "Type" being set to "Automatic". Automatic is not always perfect but it will do for this right now.\
Hit slice and you should see your sprite split up by boxes around each frame of the animation.

![SlicingSprites](SlicingSprites.JPG)

When you head back to Unity you can click on the little arrow on the right of the sprite sheet and it will expand to show the newly split sprites.\
Awesome, we are now ready to put these together into animations.

### Animations

We are going to take a moment first to talk about what an animation is as Unity defines it a differently than what you might.\
An animation is not limited to just a changing our sprite. Animations are changing any value over time. Using the same animations we make our sprites in we can also set the players transform to go up, change the color of the sprite, or any other value on that object.\
We will stick to just sprites for right now though.\
This is the first part of Unity's animation system. The actual animation clip, or changing values of an object.

To start we need to replace the sprite from the [last lesson](./1%20PlayerController.md) with our new one.\
Do this by expanding the arrow on the side of the sprite in the folders and drag the very first one into the player's sprite in the inspector.\
Now this will mess up the colliders. You will need to adjust these **and** the ground check point. Once that's done you may have a object like this :

![ReadjustedColliders](Images/ReadjustedColliders.JPG)

At first glance you may think we haven't covered the whole object but this isn't an issue. Anything that would hit, say the sword arm, will just pass through and end up hitting the body. No big deal.

Now we can begin the animation.\
At the top of Unity click on "Window", then scroll down to "Animation" and in the sub menu that pops out click "Animation". Place this window wherever.\
You will see that it is telling us we need to create an "Animation Clip". Go ahead an press create. You should place this in a new folder called "Animations". Name the animation "PlayerIdle".

Now when you go into the animation folder you will see two items have been created.

![GeneratedAnimationItems](Images/GeneratedAnimationItems.JPG)

The one on the left, with the squares and lines, is not important right now. Do not delete it as we will be coming back to it later, for now just name it "PlayerAC".

#### The Animation Window

The item on the right, with the big play button, is what we want. This is our animation. Click on it and it should open in the Animation window.\
real quick click on the gear on the far right of the window and click "Show Sample Rate".\
You should have your window looking like this :

![AnimationWindow](Images/AnimationWindow.JPG)

To start changing a property with the animation we need to press "Add Property". This is likely greyed out and this is because we need to have an object selected in the hierarchy in order to change one of it's properties.\
Click on the player object. Now you can press the "Add Property" button.\
A drop will come out listing every component on the object. Inside each of those is another list of (more or less) all the public values.

Since we want to change the sprite we should look under "Sprite Renderer" and find the "Sprite" property. Click the little plus icon beside it.\
You will now see the sprite listed in the animation. Let's break this down

![AnimationWindowWithProperty](Images/AnimationWindowWithProperty.JPG)

*You can also click the drop down on the sprite to see a mini preview.*

On the left you will see controls for playing and pausing the animation. You should see the name of the animation you are editing, the sample rate (how many frames are in a second), and a few buttons to add points on the time line.\
Below that are the properties that are part of this animation. These are what we change.\
And on the right is the timeline. This shows what the properties should be at what points in the animation. These points are called "keyframes".

#### Animating Sprite Sheets

Now we can actually have the sprite change. Luckily since this is very common in Unity it does most of the work for us.\
Go into the sprites folder and expand the sprite sheet. Click on the first sprite there and then shift-click on the fourth. All four sprites will be selected.\
These four make up our idle animation. If you are wondering how we know this is is better visualized if you look at the [full sprite sheet](Assets/SoliderSpriteSheet.png). The first row contains the idle animation and it's four sprites long.

We've got a bit of a fib here. Remove the sprite property from the animation window by clicking the little icon on the right side of the property. We just wanted that for a visual to demonstrate adding a property by hand.\
With an empty animation and these four sprites selected, drag the sprites onto the animation window.

![SpritesInAnimation](Images/SpritesInAnimation.JPG)

Unity has automatically added the sprite property and a key frame for each sprite. Awesome, that means we're done! Not quite, try hitting play on the animation window.\
Yeah unless he drank a few hundred cups of coffee that doesn't look like an idle stance.\
The problem is that Unity thinks there is sixty frames per second. Remember when we turned on "Show Sample Rate"? This is where that comes in handy. Just below the play buttons change sample rate to four. You can make this a little higher if you want it faster.

When you play the game you should see that your player moves around while playing the idle animation. If for some reason the player does not check that there is a "Animator" component added to the player (Unity should do this when you make the animation).\
If it's not, add an "Animator" component to the player and set the "Controller" to "PlayerAC" (which should be the only avaliable option). This should fix the problem for now.

Next we are going to setup the next two animations on our sheet in the same way.\
Start by making a new animation by clicking on the name right below the animation windows controls. This should have the name of the currently selected animation. Here click "Create New Clip" and name it "PlayerRun".\

![CreateNewClip](Images/CreateNewClip.JPG)

*If the animation window seems to have greyed out buttons just make sure you have the player object selected in the hierarchy.*\
Make sure you place this in the animation folder. Now all we should need to do is select and drag the next eight sprites from the sheet into the animation. Set the sample rate to something appropriate.\
That should be good, the player should now be running in place.

Do the exact same thing with the next eight sprites and make the "PlayerAttack" animation. **Careful**, the very last sprite is not part of that animation.\
You should now have three animations in your animation folder, "PlayerIdle", "PlayerRun", and "PlayerAttack". Go through and look at all of these in the animation window and make sure they are correct.

With that we can now get these hooked up to our game.

### Animation Controllers