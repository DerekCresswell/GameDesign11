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
Let's go over the three main parts of making a `for` loop.

* F
* O
* R