/*
 * ___________________________________________________
 * 
 *                     GameDesign11 
 * ___________________________________________________
 *  An intro to 2D Game Design using the Unity Engine
 * 
 * Author: DerekCresswell
 * https://github.com/DerekCresswell/GameDesign11
 * 
 * This will let the player move using your keyboard.
 * 
 */

/*
 *
 * --- What You Need To Do ---
 * 
 * Create a player object with :
 *  A 2D collider
 *  A Rigidbody2D with :
 *      0 for "Gravity Scale"
 *      A frozen Z rotation
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // The speed the player should move at
    public float moveSpeed = 1f;

    Rigidbody2D rb;
    Vector2 movement;

	void Start() {

        // Grabs the Rigidbody2D from this object
        rb = GetComponent<Rigidbody2D>();

	}

    // Update is used for general things like capturing input
	void Update() {

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

	}

    // FixedUpdate is for physics / movement
    void FixedUpdate() {

        // Figures out the desired position and sets it
        Vector2 moveTo = rb.position + movement * moveSpeed * Time.FixedDeltaTime;
        rb.MovePosition(moveTo);

    }

}