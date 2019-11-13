
# Dice Game

Here we will be talking about boolean algebra and how we can use logic in our code to create smarter code.

## Boolean Logic

We've already talked about how [booleans](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/bool) can be a true or a false value but now we will use them to decide what to do with our code.

### Boolean Operators

In the [previous lesson](./3%20Variables.md/#booleans) we mentioned that booleans can be set using the [Greater Than](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/comparison-operators#greater-than-operator-) `>` and [Less Than](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/comparison-operators#less-than-operator-) `<` signs. These are what we call ["operators"](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/).\
Operators do things to our values. For instance the ["Addition Operator"](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#addition-operator-) `+` and similar are also operators, just not for booleans.\
Here are all commonly used operators.

### Equal To

This might seem a little weird at first but if we want to seem if two things are equal we use ["Equality Operator"](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators#equality-operator-) `==`.\
The reason being that a single `=`, the ["Assignment Operator"](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/assignment-operator) assigns a value to a variable. If we tried to use this when comparing values the computer would get confused.\
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
// While this will not error, it will give you results you might not expect.
```

### Greater And Lesser Than

As stated above we've talked about `<` and `>` being used to see which side of the operator is larger.\
A very common situation is wanting to is if a value is larger **or** equal to another value. The single signs only count if the value is larger or lesser. If the two are equal they return false.\
To compare [greater](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/comparison-operators#greater-than-or-equal-operator-) / [lesser](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/comparison-operators#less-than-or-equal-operator-) or equal to we can use two shorthad operators. `<=` and `>=`.

These are most useful for number values.

```csharp
bool myBool = 3 < 3;
// myBool is false.

myBool = 3 <= 3;
// myBool is true.
```

### NOT Operator

Now we start into some new [territory](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators). The ["NOT Operator"](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators#logical-negation-operator-) is specifically for booleans. We use the `!` exclamation mark to denote this operator.\
This simply switches our boolean. `true` becomes `false` and `false` becomes `true`.

We write it like this.

```csharp
bool myBool = !true;
// myBool is false.

myBool = !myBool;
// myBool is true.

myBool = !!myBool;
// myBool is still true.
```

Here we will show you a new tool to see how these work. Truth tables.\
Now that our operator works only with bools we can easily lay out all possibilities. Here represented using `1` for `true` and `0` for `false`.

`B = !A`

A | B
--- | ---
`0` | `1`
`1` | `0`

This is a simple one but shows off the use of truth tables well.

### AND Operator

The ["AND Operator"](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators#conditional-logical-and-operator-) checks to see if both of two booleans are true. If either or both are false the operator returns false.\
We use the `&&` double ampersand with a boolean on each side to denote this operator. Just like this :

```csharp
bool myBool = true && false;
// myBool is false.
```

And for all possibilities here's the truth table.

`C = A && B`

A | B | C
--- | --- | ---
`0` | `0` | `0`
`1` | `0` | `0`
`0` | `1` | `0`
`1` | `1` | `1`

### OR Operator

The ["OR Operator"](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators#conditional-logical-or-operator-) checks if either of two booleans are true. We use `||` double pipe separators to denote this function.\
Do note if both booleans are true the operator will still return true.

```csharp
bool myBool = true || false;
// myBool is true.
```

`C = A || B`

A | B | C
--- | --- | ---
`0` | `0` | `0`
`1` | `0` | `1`
`0` | `1` | `1`
`1` | `1` | `1`

There are other options for [operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators) but these are the main ones we use.

### Boolean Order Of Operations

Remember that boolean statments still use an [order of operations](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators#operator-precedence) when calculating.\
The order is as follows :

1. Parentheses `()`
1. NOT operator `!`
1. AND operator `&&`
1. OR operator `||`

If there are two or more of the same on a single line it will be evaluated left to right.

```csharp
bool myBool = !true || false;
// myBool is false.
// !true is evaluated first followed by the ||.

myBool = !(true || false);
// myBool is true.
// The || is evaluated first followed by the !.

myBool = true && false || true;
// myBool is true.
// The && is evaluated first followed by the ||.
```

When you are in doubt, just use parantheses.

## Control Structures

Know that we can create more complex boolean statements we need a way to use them. This is where Control structures come in.