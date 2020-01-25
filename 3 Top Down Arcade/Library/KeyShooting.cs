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
 * This script will allow you to shoot projectiles
 * using the arrow keys.
 * This is an eight point system. Meaning you can 
 * shoot up, down, left, right, and on diagonals.
 *
 */

/* 
 *
 * --- What You Need To Do ---
 *  
 * Remove the arrow keys from the "Horizontal" and
 * the "Vertical" axes in Unity's Input Manager.
 * 
 * Create a "bullet prefab" that has a Rigidbody2D.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyShooting : MonoBehaviour {

	// The bullet you want to shoot
	// Requires : Rigidbody2D
	public GameObject bulletPrefab;

	// Speed for the bullet to shoot out at
	public float bulletSpeed = 1;

	void Update() {

		Vector2 shootDirection = Vector2.zero;

		// Check if our bullet should go left or right
		if(Input.GetKeyDown("left")) {
			shootDirection.x = -1f;
		} else if(Input.GetKeyDown("right")) {
			shootDirection.x = 1f;
		}

		// Check if our bullet should go up or down
		if(Input.GetKeyDown("up")) {
			shootDirection.y = 1f;
		} else if(Input.GetKeyDown("down")) {
			shootDirection.y = -1f;
		}

		// If shootDirection has been set shoot a bullet
		if(shootDirection != Vector2.zero) {

			ShootBullet(shootDirection);

		}

	} // End of Update function

	void ShootBullet(Vector2 direction) {

		// Create a bullet at the players current position
		GameObject bullet = Instantiate(bulletPrefab, 
								transform.position,
								Quaternion.identity);

		// Make sure the bullet does not hit the player
		// You may have to change the two collider types depending
		// on what you are using
		Physics2D.IgnoreCollision(bullet.GetComponent<CircleCollider2D>(), 
						GetComponent<BoxCollider2D>());

		// Add force to the bullet so it flies off
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(direction * bulletSpeed);

	} // End of ShootBullet function

} // End of PlayerController class