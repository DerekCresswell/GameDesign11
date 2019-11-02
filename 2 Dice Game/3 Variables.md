# Dice Game

Here we will talk about how to use variables to store, modify, and use data.

## Variables

Variables allow us to store values. The uses for them are near endless but common ones include storing players health, keeping track of turns, determining values for attacks or moves.\
You likely have an understanding of variables from math. While there are some things that carry over there will also be a lot of new things. Let's start with the types of variables we can have in code.

Type | Declaration | Stores | Example
---- | ----------- | ------ | -------
Integer | `int` | Whole numbers | -1, 0, 1, 2
Float | `float` | Decimal numvers | 1.0, 2.3, 4.75
Boolean | `bool` | True or False | T or F
Character | `char` | Single letters | 'a', 'b'
String | `string` | A string of letters | "Hello World"

There are more types and later on we can actually make our own. These here are just the most commonly used ones.\
So now lets talk more about each specific one.

### Integers

Integers, or ints, are the same as in math. The can only store whole numbers, positive or negative.\
One key thing to note about is using them in math. If you were to do a division like `3 / 4` you would expect to get `0.75` back. If the numbers used are ints the output must also be a whole number and anything after a decimal is truncated.\
Meaning `3 / 4` is equal to `0`. It does not get rounded, everything after the decimal is cut off.

### Floats

Floating point numbers, or floats, are real numbers. They can store decimal points unlike ints.\
Float math is does no truncate the result. Meaning when dividing two floats we keep the decimal, so `3 / 4` is equal to `0.75`. No rounding occurs.\
Now that's a bit of a fib. That equation would still equal `0`. This is because the numbers are still ints. If we wanted the computer to use float math for these we could write it like :

`3.0 / 4.0` or `3f / 4f`

Adding a decimal, even zero, or a 'f' tells the code that the numbers are floats and it will use float math.

## Declaring Variables

Can't change type.