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
 * A script that replicates the parallax effect by
 * moving oppisite to a target object.
 *
 */

/* 
 *
 * --- What You Need To Do ---
 *  
 * Place this on the object you want to move and then
 * set the object to follow to the camera.
 * 'relativeSpeed' determines the speed at which this
 * object will move at.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// The object this script moves relative to
	// This should likely be the camera object in
	// your scene
	public Transform objectToFollow;

	// The speed at which this object will move
	public float relativeSpeed;

	void Update() {

		// Get our current position
		Vector3 nextPosition = transform.position;

		// Change the X direction to be oppisite direction
		// from the object this is following
		nextPosition.x = -objectToFollow.x * relativeSpeed;

		// Set our positon to the new position
		transform.position = nextPosition;

	}

}