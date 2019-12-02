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

1. Alternate between the players turns then generating a random value for each.

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

The next part of our problem involves alternating between our players turn and then "rolling the dice". Let's start with the first bit of this problem which is taking turns.\
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
