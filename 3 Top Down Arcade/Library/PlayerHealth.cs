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
 * This will track the health of an object.
 * Although this is named PlayerHealth, it can easily
 * be converting to an EnemyHealth.
 * 
 */

/*
 *
 * --- What You Need To Do ---
 * 
 * Attach this to an object with a 2D collider
 * 
 * Setup up a death event.
 * 
 * Change / add tag names to choose what deals
 * damage to this object.
 *
 * To convert this into an EnemyHealth script :
 * 	Create a new C# script and copy the contents
 * 	of this to that.
 *  Change the name of the class to match the script.
 *	Change / add tag names to edit what deals damage.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth;

	int currentHealth;

	void Start() {

		// This spawns the object with max health
		currentHealth = maxHealth;

	}

	// Detects collions on the object
	void OnCollisionEnter2D(Collision2D collision) {

		// Set up a reference to the object we collided with
		GameObject otherObject = collision.gameObject;

		// If we collided with a bullet or enemy
		if(otherObject.tag == "BulletTag" || otherObject.tag == "EnemyTag") {

			// You'll have to switch this up with the method described
			// in 3 Health to deal damage based on what you collided with
			currentHealth--;

			// If we die
			if(currentHealth <= 0) {

				// Setup a death event
				// Perhaps load a scene or destroy this object

			}

		}

	}

}