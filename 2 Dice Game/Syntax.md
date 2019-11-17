# Dice Game

This is the basic syntax that will be followed for all the scripts in this course.

## Syntax Specifications

```csharp
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int maxHealth = 100;
    public int health = 0;

    public int maxSpeed = 10;
    [Range(0,2)]
    public float speedModifier = 1;

    bool grounded = true;

    private int level;
    private float currentExperience;

    void Start() {
    


    }
    
    void Update() {
		


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

    int ReturnFive() {return 5;}

}
```

As seen above, blocks of code should be split by one line based mainly on relevance to each other.\
Code that is very small and self explanitory, such as `ReturnFive` and the `if` in `MyFunction`, can be left with no spaces and even written on a single line.

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

    public int var1;
    public int var2;

    int var3;

    private int var4;

    void MyFunction() {

    }

}

```

New lines should be used to break up groups of similar variables.