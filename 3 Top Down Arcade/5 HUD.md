# Top Down Arcade Game 

We have working health and attacking so we should come up with a way to  display to the player all the stats.

## HUD

HUD stands for Heads Up Display.\
Unity has some great built in tools to display things like text and sliders to our players. Let's dive into this.

### Canvas

Start by making right clicking on the hierarchy and scroll down to "UI" and then click on ["Canvas"](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/UICanvas.html).\
This will create two new game objects, you need to keep both. You'll see some lines appear on the screen, this is the canvas. To get a better view select the canvas in the hierarchy and tap <kbd>F</kbd>. This is a good shortcut to remember, it will center the camera around a selected object.\
This canvas is where Unity will put all of our UI or HUD parts.

![CreateCanvas](Images/CreateCanvas.JPG)

To start, how about we just stick a piece of text on our canvas.\
Right click on the hierarchy and scroll down to "UI" and then click "Text".\
You will see that Unity has automatically placed this as a child of the canvas object. Now if you look at your game you will see that there is some text displaying. If you play the game and move around you will see that the text does not move.\
This will be the base of our HUDs. Let's start by moving this to the top right corner to be our health display. You will notice there are some extra markers popping up, this is due to our text using a ["Rect Transform"](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/class-RectTransform.html) as opposed to the normal transform. This is basically the same thing except instead of representing a point (`Vector3`) it represents a full rectangle.

Place this somewhere that looks like a good spot to display health. Here we've also changed the default text, bumped up the font size, and colored the text to appear better.

![HealthText](Images/HealthText.JPG)

That's great and all but it does not actually display our health. To do this we need some code, luckily we can do this pretty easily.

### Changing HUD Through Code

Open up the PlayerHealth script.\
At the very top we need to add a `using` statement.

```csharp
using UnityEngine.UI;
```

Then at the top of our class add in a `public` variable like :

```csharp
public Text healthText;
```

In a bit we will set this to the [text object](https://docs.unity3d.com/ScriptReference/UIElements.TextElement.html) we created.\
Now we need to change this text to display our health. the way we will do this is accessing the ["text"](https://docs.unity3d.com/ScriptReference/UIElements.TextElement-text.html) property of the text object. That will look like :

```csharp
healthText.text = "This text here";
```

This will change whatever text the object is displaying to what is after the equal sign.\
That's how you change it but now we need to figure out where to put this. There are two main options that will appear to work the exact same.

* The Update function. This would update our text every frame.
* Inside the collision function. This would update whenever our health changes.

Both work but since our health won't change every frame it would be more efficient to put this in our collision.\
We only want to change it if we actually take damage though so let's put this just below where we decrement our health.

```csharp
if(otherObject.tag == "BulletTag" || otherObject.tag == "EnemyTag") {

	currentHealth--;

	healthText.text = "Health : " + currentHealth;
```

As you can see here, we've added the `currentHealth` variable to the end of the string. You can set this string up however you want.

If you play the game and get hit by an enemy you will see that the text updates and displays your current health. But we have one more problem, before we've been hit there is no health displayed.\
This can be easily remedied by adding the same code to the `Start` function. You could also change this to perhaps say "Max Health" or do whatever you want. 