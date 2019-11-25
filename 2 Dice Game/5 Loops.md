# Dice Game

Here we will talk about loops in our code.

## Loops

We've already seen functions in our code and how they hold blocks of code so we can reuse them.\
Functions aren't always the best fit for our problems though. Lot's of the time a loop better suits our needs. Let's go over the two main types of loops we will use.

### For Loop

The "For Loop" is used to repeat through a block of code a certain amount of times.\
As usual let's get an example up and then walk through it.

```csharp
for(int i = 0; i < 5; i++) {
	Debug.Log("Hello World");
}
```

The output for this would be :

```csharp
Hello World
Hello World
Hello World
Hello World
Hello World
```

As we said, the for loop will execute a block of code a certain amount of times. In our case printing "Hello World" five times.\
Let's go over the three main parts of making a `for` loop which you can remember with the mnemonic F.O.R. suprisingly.

* **F**irst
	We need to initialize a variable that keeps track of how many times we've looped.\
	Typically you'll see `int i = 0;`. This is common because whole numbers (`int`) nicely keep track of the number of loops as we don't need to worry about decimals. `i` is typically used as it can stand for "iterator" though you can use anything. `0` is the start value as computers actually start counting at 0, again you can set it to whatever and sometimes you will want to.\
	This is value is only set once.
	
* **O**perator
	Than we need an operator to figure out if we should continue looping.\
	The second part of the statement, in this case `i < 5;`, will determine, via a boolean or boolean statement, whether we continue looping. This can be whatever you want again as long as it give you `true` or `false`.\
	This is done every iteration of the loop before the code is executed.

* **R**epeat
	Lastly, if we do another loop we do something to our variable to progress the loop.\
	The last bit of the statement in our case is `i++` which simply increases `i` by one. You can do whatever you here not just `++` (that feels like a trend).\
	This is done after the code is executed.
	
Now let's show a more visual way to think of a loop.\
You can imagine :

```csharp
for(int i = 0; i < 5; i++) {
	Debug.Log("Hello World");
}
```

turning into :

```csharp
int i = 0;
if(i < 5) {
	Debug.Log("Hello World");
}
i++;
// Loop back to the if!
```

This misses some of the nuances of the loop but will do for our purposes.\
Use loops to repeat code a certain amount of times or until a condition is met.

### While Loops

