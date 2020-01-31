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
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	// The player you want to follow
	public GameObject player;

	// Maximum speed of the enemy
	public float moveSpeed;

	// Should the enemy rotate
	public bool allowRotation = true;

	// How close does the enemy need to be to begin chasing the player
	// Set to infinity to always chase
	public float maxChaseDistance = Mathf.Infinity; 

    // Start is called before the first frame update
    void Start() {
    
		// Find the Player tag
		player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update() {

		// Are we close enough to the player to "see" them
		if(Vector3.Distance(transform.position, player.transform.position) < maxChaseDistance) {

			// Move the enemy
			Vector3 moveTo = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
			transform.position = moveTo;

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
