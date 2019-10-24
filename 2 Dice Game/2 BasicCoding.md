# Dice Game

Here we are going to write our first program.

## Basic Coding

To begin we need to know where to actually write our code.\
In the Editor duh!\
Not exactly we can't just put it anywhere in this file. For this we need to use the `Start()` function.\

Let's just talk a bit more about those functions.\
The `Start` and `Update` functions are inside of the `class TestScript`. How do we tell this? the `{}`!\
You can more or less think of `{}` or curly braces as a container. When we make our `class` we "open" a curly brace, put what we want in the class inside the brace, then "close" the brace.\
So if you look at the code below you'll notice after we "declare" our `class` we have a `{` then at the bottom of the code a `}`. So everything between these two brackets is inside the `class TestScript`.

```
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

```
	void Start () {
	
	}
```

Since we want to write inside this function we can type it on the line after `void Start() {` but before the `}`.\
Let's type this in `Console.WriteLine("Hello World");`. For now just write this exactly and we'll customize it later.\
The function should look like this :

```
	void Start () {
		Console.WriteLine("Hello World");
	}
```

*Note my spacing, we'll bring that up later as well.*

Save this script and return to Unity.