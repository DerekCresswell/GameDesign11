/*
 * ___________________________________________________
 * 
 *                     GameDesign11 
 * ___________________________________________________
 *  An intro to 2D Game Design using the Unity Engine
 * 
 * Author: Derek Cresswell
 * https://github.com/DerekCresswell/GameDesign11
 * 
 * This script provides a basic chase AI.
 *
 */

/* 
 *
 * --- What You Need To Do ---
 * 
 * Ensure there is an object in your scene with the
 * "Player" tag attached.
 * 
 * Create a enemy object with :
 *  A 2D collider
 *  A Rigidbody2D with :
 *      0 for "Gravity Scale"
 *      A frozen Z rotation
 *      Continous Collision Detection
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour {

	// The player you want to follow
	public GameObject player;

	// Maximum speed of the enemy
	public float moveSpeed;

	// Should the enemy rotate
	public bool allowRotation = true;

	// How close does the enemy need to be to begin chasing the player
	// Set to infinity to always chase
	public float maxChaseDistance = Mathf.Infinity; 

	// Reference to the Rigidbody on the enemy
	Rigidbody2D rb;

	// Start is called before the first frame update
	void Start() {
	
		// Find the Player tag
		player = GameObject.FindGameObjectWithTag("Player");

		// Set the Rigidbody
		rb = GetComponent<Rigidbody2D>();

	}

	// FixedUpdate is for physics like moving a Rigidbody
	void FixedUpdate() {

		// Are we close enough to the player to "see" them
		if(Vector3.Distance(transform.position, player.transform.position) < maxChaseDistance) {

			// Move the enemy
			Vector3 moveTo = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.fixedDeltaTime);
			rb.MovePosition(moveTo);

			// Checks to see if the enemy can rotate
			if(allowRotation) {

				// Rotates in the Z axis
				Quaternion rotation = Quaternion.LookRotation(
										player.transform.position - transform.position, 
										transform.TransformDirection(Vector3.up));
				transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

			}

		}

	}

}
