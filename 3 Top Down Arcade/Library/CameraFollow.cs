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
 * This gives smooth movement to the camera to follow
 * the player in a game.
 * 
 */

/*
 *
 * --- What You Need To Do ---
 * 
 * Do not have the camera childed to the player.
 *
 * Place the camera where you want it in relation to 
 * the player before you start the game.
 *
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	// Set this to the player in the game (NOT the prefab)
	public GameObject player;

	// Defines how far the camera "lags" behind the player
	// Higher value means less lag
	public float smoothingAmount;

	// Stores the difference in position between the player and camera
	Vector3 offset;

	void Start() {

		// Set the offset
		offset = transform.position - player.transform.position;

	}

	void Update() {

		// Store the desired position of the camera
		Vector3 desiredPosition = player.transform.position + offset;
		
		// Uses Lerp to smoothly move between the cameras current 
		// and desired location
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, 
									desiredPosition, 
									smoothingAmount * Time.deltaTime);
		
		// Sets the cameras position
		transform.position = smoothedPosition;

	}

}