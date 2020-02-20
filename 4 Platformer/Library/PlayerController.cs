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
 * A simple 2D controller to move an object in a 
 * platformer style.
 *
 */

/* 
 *
 * --- What You Need To Do ---
 *  
 * Create aa "input" script to control this that :
 *	Calls 'Move()' once per update
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Header("Settings")]

	// Maximum moved speed
	public float maxMoveSpeed = 1f;
	// Can you control the player while jumping / falling
	public bool canControlInAir;
	// How big of a jump do you have
	public float jumpForce = 1f;
	// How fast does a jump cancel out
	[Range(0f, 1f)]
	public float jumpCancel = 0.5f;
	// Allow the player to flip left and right
	public bool allowFlipping = true;
	// How much slower should the player move when crouched
	[Range(0f, 1f)]
	public float crouchSpeed = 0.5f;

	[Space]
	[Header("Collisions")]

	// A spot at your players feet to check for the ground
	public Transform groundCheckPoint;
	// Which layer contains the ground
	public LayerMask whatIsGround;

	// Which collider to disable when crouching
	public Collider2D crouchDisableCollider;

	[Space]

	public Rigidbody2D rb;

	// Readonly variables
	public bool isGrounded { get; private set; } = false;
	public bool isJumping { get; private set; } = false;
	public bool isFacingLeft { get; private set; } = true;
	public bool isFacingRight { get; private set; } = false;
	public bool isCrouching { get; private set; } = false;

	// Internal use variables
	private Vector2 m_Velocity;
	private Vector2 direction = Vector2.zero;
	private ContactFilter2D contactFilter;
	private PhysicsMaterial2D noFricMat;
	private PhysicsMaterial2D defaultMat;

	private bool queuedJump = false;
	private bool queuedUnCrouch = false;

	void Awake() {
	
		if(rb == null)
			rb = gameObject.GetComponent<Rigidbody2D>();

		contactFilter = new ContactFilter2D();
		contactFilter.SetLayerMask(whatIsGround);

		noFricMat = new PhysicsMaterial2D("FrictionlessMat");
		noFricMat.friction = 0f;
		defaultMat = rb.sharedMaterial;

	}

	// Called once per update in order to move the character
	// movement represents the horizontal movement of the character
	public void Move(float movement) {
		
		if(isGrounded || canControlInAir) {
			direction.x = movement;
		}

	}

	// Makes the player jump upwards when you can jump
	public void Jump() {
	
		if(isGrounded) {
			
			queuedJump = true;

		}

	}

	// Makes the player jump upwards no matter what
	public void JumpUnconditionally() {

		rb.velocity = new Vector2(rb.velocity.x, 0f);
		rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
		isGrounded = false;
		isJumping = true;
		
	}

	// Cancels out a player's jump
	public void CancelJump() {
	
		if(isJumping && rb.velocity.y > 0f) {
		
			rb.velocity -= new Vector2(0f, rb.velocity.y) * jumpCancel;
			
		}

	}

	// Flips the player and sprite
	public void Flip() {
		
		if(!allowFlipping)
			return;

		isFacingLeft = !isFacingLeft;
		isFacingRight = !isFacingRight;

		gameObject.transform.Rotate(0f, 180f, 0f);

	}

	// Starts the player crouching
	public void Crouch() {
		
		crouchDisableCollider.enabled = false;
		isCrouching = true;

	}

	// Stops crouching when the player can
	public void UnCrouch() {
		
		queuedUnCrouch = true;
		crouchDisableCollider.isTrigger = true;

	}

	void FixedUpdate() {
	
		isGrounded = false;
		// Detect collisions with anything considered ground
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPoint.position, 0.1f, whatIsGround);
		foreach(Collider2D col in colliders) {
			
			if(col.gameObject != gameObject) {
			
				isGrounded = true;
				isJumping = false;
				rb.sharedMaterial = defaultMat;
				break;

			}

		}

		// Prevent sticking to walls
		if(!isGrounded) {
			rb.sharedMaterial = noFricMat;
		}
		
		// Jump if we asked to jump
		if(queuedJump) {
			rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
			isGrounded = false;
			isJumping = true;
			queuedJump = false;
		}
		
		// Try to uncrouch if requested
		if(queuedUnCrouch) {

			bool canUncrouch = true;

			// Enable the collider as to allow detection of collisions
			crouchDisableCollider.enabled = true;
			List<Collider2D> crouchColliders = new List<Collider2D>();
			crouchDisableCollider.OverlapCollider(contactFilter, crouchColliders);

			// See if there is something blocking the uncrouch collider
			foreach(Collider2D col in crouchColliders) {

				if(col.gameObject != gameObject) {
					canUncrouch = false;
					break;
				}

			}

			// Set the crouch appropriately
			if(canUncrouch) {
				isCrouching = false;
				queuedUnCrouch = false;
				// Ensure the collider is no longer a trigger
				crouchDisableCollider.isTrigger = false;
				crouchDisableCollider.enabled = canUncrouch;
			} else {
				crouchDisableCollider.enabled = false;
			}

		}

		// Set up the velocity
		Vector2 curVelocity = new Vector2(direction.x * maxMoveSpeed, rb.velocity.y);

		if(isCrouching)
			curVelocity.x *= crouchSpeed;

		rb.velocity = Vector2.SmoothDamp(rb.velocity, curVelocity, ref m_Velocity, Time.fixedDeltaTime);

		// Decide if the player should flip
		bool flipSides = (isFacingLeft && Mathf.Sign(rb.velocity.x) == 1) || (isFacingRight && Mathf.Sign(rb.velocity.x) == -1);
		if(flipSides && Mathf.Abs(direction.x) > Mathf.Epsilon) {
			Flip();
		}

	}

}
