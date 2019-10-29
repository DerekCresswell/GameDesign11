# Dice Game

Here we are going to write our first program.

### Structure

To begin we need to know where to actually write our code.\
In the Editor duh!\
Not exactly we can't just put it anywhere in this file. For this we need to use the `Start()` function.\

Let's just talk a bit more about those functions.\
The `Start` and `Update` functions are inside of the `class TestScript`. How do we tell this? the `{}`!\
You can more or less think of `{}` or curly braces as a container. When we make our `class` we "open" a curly brace, put what we want in the class inside the brace, then "close" the brace.\
So if you look at the code below you'll notice after we "declare" our `class` we have a `{` then at the bottom of the code a `}`. So everything between these two brackets is inside the `class TestScript`.

```csharp
public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
	
	}
}
```

This is what is contained within the class `TestScript`. Using this same logic we can apply it to the `Start()` function. Look for the curly braces just after it.

```csharp
	void Start () {
	
	}
```

Since we want to write inside this function we can type it on the line after `void Start() {` but before the `}`.\
Let's type this in `Debug.log("Hello World");`. For now just write this exactly and we'll customize it later.\
The function should look like this :

```csharp
	void Start () {
		Debug.Log("Hello World");
	}
```

*Note my spacing, we'll bring that up later as well.*

### Adding Scripts To Objects

Save this script and return to Unity.\
Now we need to put our script into the scene. We do this the same way we put a component on our object.\
Let's just create a new "Empty Object" and give it a name.\
Click onto it and add our script to it. Just like you would with the collider. The name of the component will be the same you gave the script.\
It should look like this after :

![ScriptOnObject](Images/ScriptOnObject.JPG)

Now hover over "Window" along the top bar, go down to "General", and then find and click on "Console". This brings up the Console which is where Unity will type messages for us from errors, code, and the likes.\
With this open, run the game. You should see :

![ConsoleMessage](Images/ConsoleMessage.JPG)

And there you go. You've written code and passed the age old tradition of saying "Hello World".\
Now how did we do this? This might seem like a lot of info but trust me, once you get it all on paper you can break it down easier.\
Let's start small and work upwards.  

### How This Works

What does `Debug.Log("Hello World");` actually do? There's four parts to this :  

1. `Debug` is a class in Unity. We mentioned classes in the last [lesson](./1%20UnityScripts.md). In this case the class `Debug` contains lots of different functions we can use to "debug" or find and fix problems in our game.\
To use the `Debug` class simply type it and make sure you have `using UnityEngine;` at the top of your code.

1. `Log()` is one of the functions in the class `Debug`. In this case the `Log` function "prints" out text into the Console that we opened up a moment ago.\
Because this function is part of the `Debug` class we need to call from the class. What this means is if were to just call `Log("Hello World");` our code would error. Feel free to try this if you want to see for yourself.\
They way we call `Log` on `Debug` is by using the period `.` or the dot as it is commonly refered to. The dot allows us to "access" function or variable from something like a class.\
When we write `Debug.Log` we are calling the `Log` function that is part of the `Debug` class.\
We also have the brakcets, `()`. These are similar to the curly braces but rather than containing the code to make up a function or class they contain the values "pased" into our function.

1. `"Hello World"` is a "string" passed as a value into the function `Log`. These values must be within the brackets `()` of the function.\
In the next lesson we'll talk about what string means so for now just call it a value. A function can take values and use them to do just about anything, in our case write out the value.\
The quotation marks `""` are specific to strings and not any value passing into a function.

1. `;` denotes the end of a command. A command can be setting variables, functions, and a bunch more. Typically every line of code (not of the text editor) needs to end with a semi colon.\
Obviously there is not a semicolon after the curly braces. I hesitate to say this is a rule but it is the norm.

As shown above we have looked the structure that upholds the rules of code. Code not written with these rules will error and not run.\
In the next lesson we will go over some more of the building blocks of code and will begin to manipulate data.