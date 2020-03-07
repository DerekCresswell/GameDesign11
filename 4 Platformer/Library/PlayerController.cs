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
 * Create an "input" script to control this script that :
 *	- Calls 'Move()' once per update
 *
 * Ensure you attach this to an object with a 
 * Rigidbody2D, a "head" Collider2D, a "foot"
 * Collider2D, and a childed empty object at the
 * bottom of the main objects feet.
 *
 */

 /*
  *
  * --- API ---
  *
  * This is the info for all the functions and
  * variables that you can use from this script.
  *
  * -- Functions --
  *
  * Move (float movement)
  *  Call this at the end of the 'Update' function
  *  to move your object.
  *  - 'float movement', the amount you want to move
  *    the object left or right.
  *
  * Jump ()
  *  Call this to make your object jump if you are on
  *  the ground. Jumps straight up.
  *
  * JumpUnconditionally ()
  *  Makes the object jump instantly, even if not on
  *  the ground.
  *
  * CancelJump ()
  *  Cancels the current jump bringing the player to
  *  the ground faster.
  *  This should be called whenever the object is not
  *  jumping, as in more than once. This deals with 
  *  the current jump state so it can be called even
  *  when on the ground with no side effects.
  * 
  * Crouch ()
  *  Makes the object crouch by disabling the
  *  collider set to the 'crouchDisableCollider'
  *  variable.
  *  The object will stay crouched until 'UnCrouch' is
  *  called.
  *
  * UnCrouch ()
  *  Makes the object un-crouch by enabling the
  *  collider set to the 'crouchDisableCollider'
  *  variable.
  *  If this collider is blocked it will be enabled
  *  again as soon as it can be.
  *
  * -- Variables --
  * 
  * bool isGrounded
  *  Tells you if the object is currently standing on
  *  the ground.
  *
  * bool isJumping
  *  Tells you if the object is currently jumping.
  *
  * bool isFacingLeft
  *  Tells you if the object is facing left. This is
  *  defaulted to true, if your object is not facing
  *  left to start, set the 'Y' rotation to '180'
  *
  * bool isFacingRight
  *  Tells you if the object is facing right. This is
  *  defaulted to false. If this is the starting
  *  orientation of your object set the 'Y' rotation
  *  to '180'.
  *
  * bool isCrouching
  *  Tells you if the object is currently crouching.
  * 
  * bool landed
  *	 Is true if the object landed, meaning it became
  *	 grounded this frame.
  *
  * Vector2 currentVelocity
  *  Gives you the current X and Y velocities of the
  *  object. 
  *
  * @TODO pretty up the inline comments.
  * @TODO add tool tips for public variables.
  * @TODO add raycast wall jumping / jump direction
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
	public bool landed { get; private set;} = false;
	public Vector2 currentVelocity { get; private set; } = Vector2.zero;

	// Internal use variables
	private Vector2 m_Velocity;
	private Vector2 direction = Vector2.zero;
	private ContactFilter2D contactFilter;
	private PhysicsMaterial2D noFricMat;
	private PhysicsMaterial2D defaultMat;

	private bool queuedJump = false;
	private bool queuedJumpUnconditonally = false;
	private bool queuedUnCrouch = false;
	private bool lastFrameGrounded = false;

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
			direction.x = Mathf.Clamp(movement, -1f, 1f);
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
		
		queuedJump = true;
		queuedJumpUnconditonally = true;

	}

	// Cancels out a player's jump
	public void CancelJump() {
	
		if(isJumping && rb.velocity.y > 0f) {

			// @TODO can this be done with forces?
			// @TODO or should this have a Queued bool
			// to avoid GetButton and work with only getButtonDown
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
	
		// Detect collisions with anything considered ground
		isGrounded = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPoint.position, 0.1f, whatIsGround);
		foreach(Collider2D col in colliders) {
			
			if(col.gameObject != gameObject) {
			
				isGrounded = true;
				isJumping = false;
				rb.sharedMaterial = defaultMat;
				break;

			}

		}

		// Set landed bool
		if(!lastFrameGrounded && isGrounded)
			landed = true;
		else
			landed = false;

		lastFrameGrounded = isGrounded;

		// Prevent sticking to walls
		if(!isGrounded) {
			rb.sharedMaterial = noFricMat;
		}
		
		// Jump if we asked to jump
		if(queuedJump) {

			if(queuedJumpUnconditonally) {
				rb.velocity = new Vector2(rb.velocity.x, 0f);
				queuedJumpUnconditonally = false;
			}

			rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
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
		Vector2 targetVelocity = new Vector2(direction.x * maxMoveSpeed, rb.velocity.y);

		if(isCrouching)
			targetVelocity.x *= crouchSpeed;

		rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, Time.fixedDeltaTime);

		// Decide if the player should flip
		bool flipSides = (isFacingLeft && Mathf.Sign(rb.velocity.x) == 1) || (isFacingRight && Mathf.Sign(rb.velocity.x) == -1);
		if(flipSides && Mathf.Abs(direction.x) > Mathf.Epsilon) {
			Flip();
		}

	}

	void Update() {
	
		// Update user facing velocity
		currentVelocity = rb.velocity;

	}

}
