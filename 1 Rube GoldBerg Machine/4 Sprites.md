# Rube Goldberg Machine

The last section we are going to talk about are Sprites. You might've noticed that we've already been using these in the form of our "WhiteCircle" and "WhiteBox", which is correct. There's a lot more to Sprites than this, more than we could cover now.\
For now, we will just go over putting your own sprites into the game using them in a few ways.

## Sprites

You might be wondering why we've called our images "Sprites". Sprite is simply the common name used for a 2D Graphic used in a game.\
The origin of the name is that Sprite is another word for a ghost. In our game the Sprites float on top of our background like they are ghosts.\
Just an interesting fact for you.

### Importing Sprites

Before we can use a sprite we need to actually put it into our game. We're going to do the same thing we did with the "WhiteBox" and "WhiteCircle" but this time I'm going to let you choose the Sprite.

For this let's get three different Sprites.\
We are going to need :
* A background.
* A ground / box.
* And a circular object.

To find these you can simply google "Video game sprites ______" and insert what you want. Sometimes you might need to play with the wording lots to find the right one or a few that work well together.\
You will likely need these to be PNG files otherwise they might look very odd or cut off parts of the game.\
If you are an artist, don't worry. There will be better opportunities later to make your own Sprites.\
Here are the ones I found :

<p float="left">
  <img src="Images/Mountains.png" width="100" />
  <img src="Images/PokeBall.png" width="100" /> 
  <img src="Images/WoodenCrate.png" width="100" />
</p>

After you have these three sprites go ahead and import them into Unity as we did in the [Game Objects Lesson](/2%20GameObjects.md). Refer back to that if you need a refresher.\
Once you've got those in the file we are going to use them in place of the circle and box we've been using.\
After that your game should be looking a little more custom like so :

![CustomSprites](Images/CustomSprites.JPG)

Parts of mine look okay but the ramps look very stretched. It's likely your sprites look bigger or larger than they should also.\
This would be mainly cause by the size of image. The grid shown in Unitys Scene is 100 by 100 pixels. If your image is larger or smaller than this it will appear distorted.\
An easy way to fix this is to scale the image to 100 by 100 in photoshop or we can do it with Unitys built in editor.\
If you want to use the built in editor this is how :

//In unity editor

//Tile Sprites later

### Backgrounds With Sprites

Now let's get the background in here. We are just going to do a simple but effective way to make this.\
Start by making a new Sprite, like we've done before, and name it "Background."
