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

1. Alternate between the players turns generating a random value for each.

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
