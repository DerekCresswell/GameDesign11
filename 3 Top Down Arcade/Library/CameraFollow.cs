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
 */

/*
 *
 * --- What You Need To Do ---
 * 
 * Do not have the camera childed to the player
 * Place the camera where you want it in relation to the player before you start the game.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	// Set this to the player in the game (NOT the prefab)
	public GameObject player;

	// Stores the difference in position between the player and camera
	Vector3 offset;

	void Start() {

        // Set the offset
		offset = transform.position - player.transform.position;

	}

	void Update() {

		// Update the cameras position
		transform.position = player.transform.position + offset;

	}

}