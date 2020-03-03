# Platformer

Here we will discuss how to make and use animations in Unity.

## Unity's Animation System

Unity has a **very** powerful [animation system](https://docs.unity3d.com/Manual/AnimationOverview.html). We could very easily get lost within this so we will have to focus down on a small part of it that we will start to use.

First let us talk about the type of animation we will be doing. Sprite based animations, or sprite sheet animation, think the original Super Mario. This is opposed to rigging based, think a Call Of Duty character.\
Sprite sheet animation is where we have basically a list of pics each defining a frame of the animation, or a pose. Checkout the image below :

![MarioRun](Images/MarioRun.JPG)

You can see each frame is a distinct point in Mario's run animation. We can then put these one after another to create an animation for our character.

// Distinguish between animation and controller
// Get knight sprite sheet or change over pictures from last.