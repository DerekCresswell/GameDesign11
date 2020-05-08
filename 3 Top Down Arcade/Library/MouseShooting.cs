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
 * This script will allow the player to track the
 * mouse and shoot bullets in it's direction.
 *
 */

/* 
 *
 * --- What You Need To Do ---
 *  
 * Create a "bullet prefab" that has a Rigidbody2D.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShooting : MonoBehaviour {

	// The bullet you want to shoot
	// Requires : Rigidbody2D
	public GameObject bulletPrefab;

	// Speed for the bullet to shoot out at
	public float bulletSpeed = 1;

	// Delay between shots
	public float shootDelay;

	private float timer = 0;

	void Update() {

		// First we find where the mouse is looking at by using a function on the camera
		// Then set the Z to zero because we are 2D
		Vector3 aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		aimPosition.z = 0;

		// Then we find the angle our player should be at and look there
		float angle = Mathf.Atan2(aimPosition.y,aimPosition.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		// The time since the last shot has been longer than the delay
		if(timer > shootDelay) {
			
			// Is the left mouse key down
			if(Input.GetKey("mouse 0")) {

				// Make sure aimPosition is between -1 and 1
				aimPosition.Normalize();

				// Shoot the bullet
				ShootBullet(aimPosition);
				timer = 0;

			}

		}

		timer += Time.deltaTime;

	}

	void ShootBullet(Vector2 direction) {

		// Create a bullet at the players current position
		GameObject bullet = Instantiate(bulletPrefab, 
								transform.position,
								Quaternion.identity);

		// Make sure the bullet does not hit the player
		// You may have to change the two collider types depending
		// on what you are using
		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), 
						GetComponent<Collider2D>());

		// Add force to the bullet so it flies off
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(direction * bulletSpeed);

	}

}
