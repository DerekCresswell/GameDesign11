# Dice Game

Here we will talk about how to use variables to store, modify, and use data.

## Variables

Variables, or vars, allow us to store values. The uses for them are near endless but common ones include storing players health, keeping track of turns, determining values for attacks or moves.\
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

Here we'll stick in the fact that all math we use in code does follow the order of operations (BEDMAS). If we were to do `5 + 3 / 4` with ints we would get `0` and not `2`. Though you can write `(5 + 3) / 4` and get `2` back.\
This goes for the next variable type, floats, as well.

### Floats

Floating point numbers, or floats, are real numbers. They can store decimal points unlike ints.\
Float math is does no truncate the result. Meaning when dividing two floats we keep the decimal, so `3 / 4` is equal to `0.75`. No rounding occurs.\
Now that's a bit of a fib. That equation would still equal `0`. This is because the numbers are still ints. If we wanted the computer to use float math for these we could write it like :

`3.0 / 4.0` or `3f / 4f`

Adding a decimal, even zero, or a 'f' tells the code that the numbers are floats and it will use float math.

### Booleans

Booleans, despite only having two possible values, are likely the most useful and can become very complex.\
Acceptable values for booleans are, `true` and `false` or `1` and `0`.\
The zero and one are just like binary if you know what that is.\
Booleans are how we interact with "control structures" which we will get to later and are the most useful part of coding.

Booleans can be set with values like `5 > 4` which would give the variable a value of true. A similar order of operations applies to booleans as well but we will talk about that during control structures.

### Characters

Characters, or chars, are single letters. There isn't too much fancy stuff here.\
Characters must be wrapped in single quotes like `'a'` and contain no extra spaces. Most symbols, like `'!'` or `'&'` will work. Some do have specific codes you will have to look up.\
Capitals do matter as `'a'` is not the same as `'A'`.

### Strings

Strings, or strings (yeah there's not really a nickname), are actually just a list of characters.\
They can contain all letters and symbols that are valid characters. Again, certain special characters will require you to look up how to use them.\
When creating a string it must be wrapped in quotations `""`, like `"Hello World"`.\
Strings are very specific and case sensitive. `"Hello World"` is not the same as `"hello world"` or `"HelloWorld"`.

## Declaring Variables

Can't change type.