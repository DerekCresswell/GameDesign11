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

		offset = transform.position - player.transform.position;

	}

	// Update is called once per frame
	void Update() {

		// Update the cameras position
		transform.position = player.transform.position + offset;

	}
}