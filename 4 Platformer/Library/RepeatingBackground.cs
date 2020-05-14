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
 * A script for repeating or "tiling" a background to
 * create the effect of an infinite background.
 *
 */

/* 
 *
 * --- What You Need To Do ---
 *  
 * Create a background of three identical tiles layed
 * out one after another.
 * 
 * Attach this script to a "holder" object containing
 * those background tiles.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// The three tiles to use for the background
	// These should likely be identical otherwise
	// the size will break
	public GameObject leftTile;
	public GameObject middleTile;
	public GameObject rightTile;

	// The player's transform
	public Transform player;

	// Stores the size of the tiles
	private float size;

	void Start() {

		// Get the size of the tile in the x direction
		size = middleTile.GetComponent<Renderer>().bounds.size.x;

	}

	void Update() {

		// For convenience store the x positions of the middle
		// tile and the player
		float playerX = player.position.x;
		float middleTileX = middleTile.transform.position.x;

		// Calculate the left most and right most point of the
		// middle tile
		float leftBound = middleTileX - size / 2;
		float rightBound = middleTileX + size / 2;

		if(playerX < leftBound) {

			// The player is over the left tile
			GameObject tempTile = leftTile;
			leftTile = rightTile;
			rightTile = middleTile;
			middleTile = tempTile;

			// Move the left tile to it's new position
			Vector3 newPosition = leftTile.transform.position;
			newPosition.x = middleTile.position.x - size;
			leftTile.transform.position = newPosition;

		} else if(playerX > rightBound) {

			// The player is over the right tile
			GameObject tempTile = leftTile;
			leftTile = middleTile;
			middleTile = rightTile;
			rightTile = tempTile;

			// Move the right tile to it's new position
			Vector3 newPosition = rightTile.transform.position;
			newPosition.x = middleTile.position.x + size;
			rightTile.transform.position = newPosition;

		}

	}

}