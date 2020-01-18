# Dice Game

This is the basic syntax that will be followed for all the scripts in this course.\
The rules outlined here are by no means required or the only way to organize code. You may write your code however you'd like and nearly every developer will have a different method.\
The style for this course has been outlined so you don't need to spend time deciphering the formatting of the code. If you need to find a function, you'll know where it should be located.

## Syntax Specifications

```csharp
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int maxHealth = 100;

    public int maxSpeed = 10;
    [Range(0,2)]
    public float speedModifier = 1;

    bool grounded = true;
    int health = 0;

    private int level;
    private float currentExperience;

    void Start() {
    
        health = maxHealth;

    }
    
    void Update() {
		
		if(Input.GetKeyDown("Space")) {
			Attack();
		}

    }

	void Attack() {

		// Code

	}

}
```

Above is just an example file with most things you will come across in this course. It is not meant to be used in a game.\
If something does not look right or feel right don't follow it. This is just a general idea to get you started.

### Indenting and New Lines

All code is to be indented based on scope as usual.

```csharp
class Test {

    void MyFunction() {

        if(true) {
            int myInt;
        }

    }

    int ReturnFive() {
        return 5;
    }

}
```

As seen above, blocks of code should be split by one line based mainly on relevance to each other.

### Casing

Which casing standard to use for which parts of our code.

#### UpperCamelCase
    
* Classes
* Structs
* Functions

#### lowerCamelCase

* Local Variables

#### CAPITAL CASE

* Constants
* Static Variables

### Variables

Variables should follow the [casing style](#casing) denoted above.

```csharp
class Test {

    static int TESTVAR;

    [Range(0,1)]
    public int var1;
    public int var2;

    int var3;

    private int var4;

    void MyFunction() {

    }

}
```

New lines should be used to break up groups of similar variables.\
Properties (Header, Range, Serializable) are placed on the line preceding their coresponding variable.\
Arrange variables based on their Access Levels. Typically top to bottom like :

* Static
* Public
* Default
* Private

### Spacing

Leaving spaces between characters can increase readability. We will leave spaces around equal signs `=`, after commas `,`, and before opening curly braces `{`.

```csharp
if(myBool) {

	myInt = 9;
	myFunc(myInt, true);

}
```