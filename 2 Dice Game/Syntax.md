# Dice Game

This is the basic syntax that will be followed for all the scripts in this course.

## Syntax Specifications

```csharp
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[Header("Health Settings")]
    public int health = 0;
    public int maxHealth = 100;

    [Header("Speed Settings")]
    public int maxSpeed = 10;
    [Range(0,2)]
    public float speedModifier = 1;

    bool grounded = true;

    private int level;
    private float currentExperience;

    void Start () {
    


    }
    
    void Update () {
		


    }

}

```