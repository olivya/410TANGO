//this script is responsible for: (1) moving character around (2) telling the animator what the parameters are (basically just be updating some parameters)
//this script is NOT responsible for: (1) telling animator how to animate (2) telling animator what state it's in, etc.

using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float maxSpeed = 10f;
	public float dropSpeed = 10f;
	public bool facingRight = true;
	Animator anim; //reference to Animator
	
	//set up for falling:
	public bool grounded = false; //check if on ground (starts slightly above)
	public Transform groundCheck; //create another object to represent where the ground should be in relation to the character
	float groundRadius = 0.2f; //how big our sphere is going to be when we check for the ground
	public LayerMask whatIsGround; //need to tell character what is considered ground - water? bullet? enemies? (what can the character land on?)
	public float jumpForce = 700f;

	// set up for hovering
	public float hoverForce = 400f; //amount of boost when initiating hover
	public float hoverGravity = 0.5f;
	public float totalHoverTime = 10;
	float hoverTimeRemaining;
	bool hovering = false; //meaning we've not yet used our hover
	public float dropGravity = 3f;

	public Transform other;

	//public float distance;

	void Awake () {
		//distance = other.position.x - transform.position.x;
	}

	void Start () {
		anim = GetComponent<Animator>();

	}

	//using a RigidBody that animates physics, this means animator will be in sync with FixedUpdate
	//if in FixedUpdate, do not need to use Time.DeltaTime
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); //constantly check if we're on the ground - are we hitting any colliders in this ground detecting circle? will return true or false
		anim.SetBool("Ground",grounded);

		if(grounded) {
			hovering = false; //resets hover
			hoverTimeRemaining = 0;
			rigidbody2D.gravityScale = 1f; //returns gravity to normal after hovering
		}

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y); //every frame saying "this is how fast we're moving up/down" 
		float move = Input.GetAxis("Horizontal"); //by default Input.GetAxis is mapped to the arrow keys
		anim.SetFloat("Speed", Mathf.Abs(move)); //absolute value because you don't care if you're moving left or right, just the speed. the animator handles the rest.
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y); //taking current velocity, moving left or right based on what key pressed * maxSpeed, leaving y the same

		if (move > 0 && !facingRight)//if move (input) is greater than zero, and we're not facing right, flip.
			Flip ();
		else if(move < 0 &&facingRight) //else, if move is less than zero, and are ARE facing right, flip.
			Flip();
	}

	void Update() { //read more accurately than FixedUpdate, pressing spacebar might be missed otherwise


		//distance = Mathf.Abs(other.position.x - transform.position.x);
		//distance = other.position.x - transform.position.x;
		//print ("distance" + distance);

		///// SHOOTING ////

		//bool shoot = Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift); //shooting controls
		bool shoot = Input.GetKeyDown (KeyCode.Space);

		if (shoot) {
			windAtkScript weapon = GetComponent<windAtkScript>();
			if (weapon != null) {
				weapon.doAttack(false); //false because the player is not an enemy
			}
		}

		//shoot |= Input.GetKeyDown(KeyCode.Space); //can use this line to set up alternative button to press and either will work

		float verticalSpeed = rigidbody2D.velocity.y;

		///// JUMPING ////

		if(grounded && Input.GetKeyDown(KeyCode.UpArrow)) { //should go to input manager and create a jump axis or jump button and then just say jump so it's re-mappable for players
			anim.SetBool("Ground",false); //immediately say we are no longer on the ground
			rigidbody2D.AddForce(new Vector2(0,jumpForce)); //add force, so 'we're jumping now'
			//print("Jump gravity is " + rigidbody2D.gravityScale);
		}

		///// HOVERING //// (basically a double jump, where the gravity is changed on the second jump to simulate hovering

		if(!grounded && verticalSpeed > -3 && !hovering && Input.GetKeyDown(KeyCode.UpArrow)) {
			//print("Vertical speed was " + rigidbody2D.velocity.y + " when hover was initiated");
			rigidbody2D.AddForce(new Vector2(0,hoverForce)); 
			hovering = true; //we've now used our hover (so can't use it again)
			rigidbody2D.gravityScale = hoverGravity;
			hoverTimeRemaining = totalHoverTime;
			//print("Hover gravity is " + rigidbody2D.gravityScale);
		}

		//timer to limit how long player can hover
		if(hoverTimeRemaining > 0) {
			hovering = true;
			hoverTimeRemaining = hoverTimeRemaining - 1;
			//print("Hover remaining: "+hoverTimeRemaining+"/"+totalHoverTime);
		}

		if(hoverTimeRemaining == 0) {
			rigidbody2D.gravityScale = 1f; //return gravity to normal after set time
			if(grounded) hovering = false;
		}

		if(hovering) {
			rigidbody2D.gravityScale = hoverGravity;
			//print("gravity is "+rigidbody2D.gravityScale);
		}

		//dropping
		if(!grounded && Input.GetKey(KeyCode.DownArrow)) { //if player holds down key while hovering, will fall faster
			rigidbody2D.gravityScale = dropGravity;
		}

		if(!grounded && Input.GetKeyDown(KeyCode.DownArrow)) {
			print("*** Drop gravity INITIATED and is now "+rigidbody2D.gravityScale+" ***");
		}

		if(!grounded && Input.GetKeyUp(KeyCode.DownArrow)) { //if player releases down key while not grounded, gravity will return to either hovering or regular levels (depending on if hover timer is still counting down)
			if(hovering)
				rigidbody2D.gravityScale = hoverGravity;
			if(!hovering)
				rigidbody2D.gravityScale = 1f;
			print("*** Drop gravity CANCELLED and is now "+rigidbody2D.gravityScale+" ***");
		}
	}
	
	void Flip() {
		facingRight = !facingRight; //facing left
		Vector3 theScale = transform.localScale; //get local scale...
		theScale.x *= -1; //...flip the x axis...
		transform.localScale = theScale; //...and  apply it back to local scale
	}
}
