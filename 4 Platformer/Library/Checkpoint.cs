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
 * A basic way to setup a dynamic checkpoint system.
 *
 */

/*
 *
 * --- What You Need To Do ---
 *
 * Ensure this object has a 2D collider that is a
 * trigger.
 *
 * You will likely have to set or customize your
 * player health script to work with this.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	// Where to spawn the player for this point
	public Transform spawnAt;

	// The sprites to use based on the state of
	// the checkpoint
	public Sprite inactiveSprite;
	public Sprite activeSprite;

	// The SpriteRenderer attached to this point
	public SpriteRenderer renderer;

	// Is this checkpoint active
	public bool active = false;

	// A static reference to the last active point
	public static Checkpoint lastCheckpoint;

	public void OnTriggerEnter2D(Collider2D collider) {

		if(collider.tag == "Player" && !active) {

			// Set this checkpoint to be active
			active = true;
			renderer.sprite = activeSprite;

			// Set the player's spawn point
			// You may need to change this based on how your
			// player's health script works or how the variables
			// are named
			PlayerHealth pHealth = collider.gameObject.GetComponent<PlayerHealth>();
			pHealth.spawnPosition = spawnAt.position;

			if(lastCheckpoint != null) {

				// Deactivate the last checkpoint
				lastCheckpoint.active = false;
				lastCheckpoint.renderer.sprite = lastCheckpoint.inactiveSprite;

			}

			// Set the new active checkpoint
			lastCheckpoint = this;

		}

	}

	public void Start() {

		// These are here for safety incase something
		// doesn't get set
		spawnAt = transform;
		renderer = GetComponent<SpriteRenderer>();

	}

}