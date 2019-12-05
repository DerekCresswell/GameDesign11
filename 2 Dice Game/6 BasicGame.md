# Dice Game

Here we will work together to create the basic template for a dice game.

## Basic Layout

Before we jump right into coding we need to plan out our work. Though it can be really fun to just start coding but without a plan it can be very difficult to break apart a big problem like "make a dice game".

First let's go over what our dice game is :

> Two players take turns rolling dice. The value of their rolls will move them closer to winning, perhaps damaging an enemy. With each roll a story of sorts is also printed out. Once a player wins, display their victory to all.

Think of it similar to a game of Dungeons and Dragons.\
With this is mind let's disect the problem into smaller chunks. We'll start it off here than hopefully you can take over and do the rest yourself.

1. Have two "players" with a value of sorts to keep track of (EX : health).

1. Alternate between the players turns generating a random value for each.

Hopefully you can see the pattern. Take the big problem and try to break it into a smaller task.\
Try to write down the rest of what we might need. Once you are done or if you get stuck take a peek below.

<details>
<summary>The pieces of the puzzle</summary>
 
1. Have two "players" with a value of sorts to keep track of (EX : health).

1. Alternate between the players turns.

1. Generating random values for each turn.

1. Do something based off of the dice value (EX : attack, heal).

1. Print out what happened.

1. Check to see if someone has won. If so stop and print out the winner.

1. Repeat.
 
</details>

With this plan in mind we can start building a template. Follow along with this to get the idea of how we are building this game. Afterwards you will have this as a template to work with and expand for the actual dice game.

### The Players

To start let's first make a [new C# Script](./1%20UnityScripts.md#adding-scripts-in-unity) or even a new project if you'd like a fresh start.\
Give this script the name "DiceGameTemplate" or similar. Open it up and let's start coding!

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceGameTemplate : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

}
```

For the template we are going to use very generic names and story. Make sure to be more creative for your own.\
The first thing we said we would need is to keep track of values for two players. Pretty simply I will make a variable for each player.\
Now it is important where we put those variables. We want to keep these vars throughout this script and not "re-instantiate" (think of that as resetting). Remembering what we talked about during the [scope](./4%20Logic.md#scope) section of the last [lesson](./4%20Logic.md) we said that if a scope ends, such as the end of a function or `if` statement, any variables within it are deleted.\
To prevent this let's declare these variables at the top of the class like so :

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceGameTemplate : MonoBehaviour {

    int playerOneHealth = 50;
    int playerTwoHealth = 50;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

}
```

Declaring your variables here in what I will call the "class scope" means that the var can be accessed anywhere within this script. It also means that it will only be declared once when our game object with this script is loaded into the game. Remembering that we need to [attach this script to an object in our game](./2%20CodeStructure.md#adding-scripts-to-objects), the class `DiceGameTemplate` will only be created this once. In turn those two variables are only declared once.\
Here we've used `int` as the type because it makes sense for a "health" value and 50 is just an arbitrary starting point.\
That's a fine starting point and does what we needed to do in the first part of the breakdown of our problem.

### Taking Turns

The next part of our problem involves alternating between our players turns. Let's start with figuring out how we should go about this.\
This may not be inherently obvious but we are going to use another `int` and check if it is even or odd. This is a very common method.\
Start by creating another variable called "turnCounter" or similar. It will be an `int` and have an intial value of "0";

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceGameTemplate : MonoBehaviour {

    int playerOneHealth = 50;
    int playerTwoHealth = 50;
    int turnCounter = 0;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

}
```

Then as we said, we need to check it `turnCounter` is even or odd. We can do this with the ["modulus operator"](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#remainder-operator-).\
The modulus or remainder operator gives us the remainder of division between two numbers. It's used like `5 % 2` will return `1` because `2` can go into `5` twice with one left over.\
Perhaps you can see just from that how we can check for even-ness. All we need to do is take the remainder of two. If it returns one, the number is odd. If it returns zero, the number is even. We can test this like so :

```csharp
3 % 2; // Equal to 1
6 % 2; // Equal to 0
0 % 2; // Equal to 0
13 % 2; // Equal to 1
```

With this info we can test if a number is even using `if(num % 2 == 0)` where `num` is the number we are checking. Using this in our code will look like this : (full script omitted for brevity)

```csharp
    // Start is called before the first frame update
    void Start() {
        
    	if(turnCounter % 2 == 0) {
    		// Player One's Turn
    	} else {
    		// Player Two's Turn
    	}

    }
```

Just put this code into the `Start` function for now.
Now we do need to update the `turnCounter` value otherwise it will stay zero forever. We want to always increment `turnCounter` regardless of who's turn it is so we should increment the value **After** the `if` and `else` statement.

```csharp
    // Start is called before the first frame update
    void Start() {
        
    	if(turnCounter % 2 == 0) {
	   		// Player One's Turn
    	} else {
    		// Player Two's Turn
    	}

    	turnCounter++;

    }
```

That should be all for determining who's turn it is. Onto the next bit of the turns, generating the random numbers.

### Random Numbers

After getting our turns setup we need to actually do something in our turns. Otherwise this would be one boring game.\
We now need to "roll some dice". We can do this using a pre-made Unity class called ["Random"](https://docs.unity3d.com/ScriptReference/Random.html). The Random class has a method perfect for us called ["Range"](https://docs.unity3d.com/ScriptReference/Random.Range.html).\
If you open up that page you can read a bit about how it works. You can also see from the examples how we need to access this function. First we need to reference the class, `Random`, then access the `Range` function with a `.` like so `Random.Range();`.\
Now this will error because we have not given the function any parameters. If you look at the [Scripting API](https://docs.unity3d.com/Manual/index.html) it will tell you that `Range` needs two numbers. These can be either `float` or `int` types, but seeing as we are simulating dice we will only want whole numbers.\
Let's start typing it out.

```csharp
    // Start is called before the first frame update
    void Start() {
        
    	int dieOne = Random.Range(1, 7);

    	if(turnCounter % 2 == 0) {
	   		// Player One's Turn
    	} else {
    		// Player Two's Turn
    	}

    	turnCounter++;

    }
```

Alright that might seem a little weird so let's pick it apart.\
First thing is that we want to store this random number into a variable (`int dieOne`) because will need to use this number throughout the turn. If we did not store the number to a variable we'd only be able to access it once. Every time we call the `Range` function it creates a **new** number so we need to use a variable to access it more than once.\
Next is the placement. We've put it above the `if` statements because it doesn't matter who's turn it is we always need a random number. This also makes it accessiable throughout the rest of the turn and in any `if`s we have.\
The last bit is the values we've passed in, `1` and `7`. Now you could pass whatever you would like into this, here we are simply emulating a six sided die. The reason `1` is the lower limit and `7` is the upper limit is because the [Scripting API](https://docs.unity3d.com/Manual/index.html) tells us the integer version of `Range`, which we are using, has an inclusive minimum and exclusive maximum.\
What this means is the first number passed in, here being `1`, is going to be inclusive. `Range` **can** return `1`.\
The second number, here being `7`, is going to be exclusive. `Range` **cannot** return `7` but can return up to it.\
Because of these inclusive and exclusive rules the possible numbers we can get back are `1, 2, 3, 4, 5, 6` when we input `(1, 7)` into range. As a more flexible definition think of it like this.

> When we pass in the parameters `min` and `max` to `Range` we can receive a value from and including `min` up to and including `max - 1`.

All of this boils down to having `dieOne` set to a random number between one and six at the start of a players turn.

### Doing something

// MAKE TITLE BETTER

Now that we have a random number and have figured out who's turn it is, we ought to do something.\
In this template we will use the number rolled to determine the "power" of an attack and take that away from the players health. If that makes sense it's encouraged that you try doing this on your own first and see how it goes. You can always come back after and use the methods listed here. There isn't really a wrong way to do this so go ahead and try it!\
First let's list out what we'd like each dice roll to do. For the this template how about :

* `1` & `2` deal `5` damage.
* `3` & `4` deal `10` damage.
* `5` deals `15` damage.
* `6` will deal `30` damage!

Chose to do whatever you'd like for these.\
Now that we've got that plan let's start implementing it. We will simply use `if else` statements to decide on the damage.