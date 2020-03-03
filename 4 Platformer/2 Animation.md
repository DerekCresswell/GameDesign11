# Platformer

Here we will discuss how to make and use animations in Unity.

## Unity's Animation System

Unity has a **very** powerful [animation system](https://docs.unity3d.com/Manual/AnimationOverview.html). We could very easily get lost within this so we will have to focus down on a small part of it that we will start to use.

First let us talk about the type of animation we will be doing. Sprite based animations, or sprite sheet animation, think the original Super Mario. This is opposed to rigging based, think a Call Of Duty character.\
Sprite sheet animation is where we have basically a list of pics each defining a frame of the animation, or a pose. Checkout the image below :

![MarioRun](Images/MarioRun.JPG)

You can see each frame is a distinct point in Mario's run animation. We can then put these one after another to create an animation for our character.

Unity's animation system is split into two main parts, animations and animation controllers. We will get more into this later. Let's start by creating a walking animation for our object.

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



### Animation Controllers