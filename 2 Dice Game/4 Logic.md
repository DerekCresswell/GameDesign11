# Dice Game

Here we will be talking about boolean algebra and how we can use logic in our code to create smarter code.

## Boolean Logic

We've already talked about how booleans can be a true or a false value but now we will use them to decide what to do with our code.

### Boolean Operators

In the [previous lesson](./3%20Variables.md/#booleans) we mentioned that booleans can be set using the `>` and `<` signs. These are what we call "operators".\
Operators do things to our values. For instance the `+` and similar are also operators, just not for booleans.\
Here are all commonly used operators.

### Equal To

This might seem a little weird at first but if we want to seem if two things are equal we use `==`.\
The reason being that a single `=` assigns a value to a variable. If we tried to use this when comparing values the computer would get confused.\
`=` sets the value of a variable where as `==` compares two values.

These can be used with most variable types.

```csharp
bool myBool = true == true;
// This is rather a pointless statement but it works.
// myBool is true.

myBool = 30 == 23;
// The equality operator is not exclusive to booleans.
// myBool is false.

myBool = 40 = 40;
// ERROR, this stament does not make sense to your computer.
```

### Greater And Lesser Than

As stated above we've talked about `<` and `>` being used to see which side of the operator is larger.