using UnityEngine;

//Same function as windAtkScript, just made another one for enemy so it doesnt affect player

public class enemyBulletAtkScript : MonoBehaviour {

	public Transform shotPrefab;
	public float shootingRate = 1f;
	private float shootCooldown;

	private bool testTest;

	void Start() {
		shootCooldown = 0f;
	}
	
	void Update() {
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}
	}

	public void Attack(bool isEnemy) {
		if (CanAttack) {
			shootCooldown = shootingRate;

			//if (GameObject.Find("enemy").GetComponent<enemyAI>().spotted){ //will check if true

			var shotTransform = Instantiate(shotPrefab) as Transform; // Create a new shot

			shotTransform.position = transform.position; // Assign position

			shotScript shot = shotTransform.gameObject.GetComponent<shotScript>(); // The is enemy property

			if (shot != null) {
				shot.isEnemyShot = isEnemy;
			}

			moveScript move = shotTransform.gameObject.GetComponent<moveScript>(); // Make the weapon shot always towards it

			if (move != null) {
				if (!GameObject.Find("enemy01").GetComponent<enemyAI>().facingRight  && GameObject.Find("enemy01").GetComponent<enemyAI>().spotted) { //determines if player is facing left & flips bullet sprite accordingly
					move.direction = this.transform.right;
					//shotTransform.localScale = new Vector2(-3, -3);
				}
				if (GameObject.Find("enemy01").GetComponent<enemyAI>().facingRight && GameObject.Find("enemy01").GetComponent<enemyAI>().spotted) {
					move.direction = this.transform.right * -1;
					shotTransform.localScale = new Vector2(-3, 3);
				}
			}

			if (move != null) {
				if (!GameObject.Find("enemy06d").GetComponent<enemyAI>().facingRight  && GameObject.Find("enemy06d").GetComponent<enemyAI>().spotted) { //determines if player is facing left & flips bullet sprite accordingly
					move.direction = this.transform.right;
					//shotTransform.localScale = new Vector2(-3, -3);
				}
				if (GameObject.Find("enemy06d").GetComponent<enemyAI>().facingRight && GameObject.Find("enemy06d").GetComponent<enemyAI>().spotted) {
					move.direction = this.transform.right * -1;
					shotTransform.localScale = new Vector2(-3, 3);
				}
			}
			
			
			
			if (move != null) {

				if (!GameObject.Find("enemy02").GetComponent<enemyAI>().facingRight && GameObject.Find("enemy02").GetComponent<enemyAI>().spotted) { //determines if player is facing left & flips bullet sprite accordingly
					move.direction = this.transform.right; // towards in 2D space is the right of the sprite
					//shotTransform.localScale = new Vector2(-3, -3);
				}
				if (GameObject.Find("enemy02").GetComponent<enemyAI>().facingRight && GameObject.Find("enemy02").GetComponent<enemyAI>().spotted) {
					shotTransform.localScale = new Vector2(-3, 3);
					move.direction = this.transform.right * -1;
				}
			}

			if (move != null) {
				
				if (!GameObject.Find("enemy07").GetComponent<enemyAI>().facingRight && GameObject.Find("enemy07").GetComponent<enemyAI>().spotted) { //determines if player is facing left & flips bullet sprite accordingly
					move.direction = this.transform.right; // towards in 2D space is the right of the sprite
					//shotTransform.localScale = new Vector2(-3, -3);
				}
				if (GameObject.Find("enemy07").GetComponent<enemyAI>().facingRight && GameObject.Find("enemy07").GetComponent<enemyAI>().spotted) {
					shotTransform.localScale = new Vector2(-3, 3);
					move.direction = this.transform.right * -1;
				}
			}

	
			if (move != null) {

					if (!GameObject.Find("enemy03").GetComponent<enemyAI>().facingRight && GameObject.Find("enemy03").GetComponent<enemyAI>().spotted) { //determines if player is facing left & flips bullet sprite accordingly
					move.direction = this.transform.right; // towards in 2D space is the right of the sprite
					//shotTransform.localScale = new Vector2(-3, -3);
				}
				if (GameObject.Find("enemy03").GetComponent<enemyAI>().facingRight && GameObject.Find("enemy03").GetComponent<enemyAI>().spotted) {
					shotTransform.localScale = new Vector2(-3, 3);
					move.direction = this.transform.right * -1;
				}
			}


			if (move != null) {
				
				if (!GameObject.Find("enemy04").GetComponent<enemyAI>().facingRight && GameObject.Find("enemy04").GetComponent<enemyAI>().spotted) { //determines if player is facing left & flips bullet sprite accordingly
					move.direction = this.transform.right; // towards in 2D space is the right of the sprite
					//shotTransform.localScale = new Vector2(-3, -3);
				}
				if (GameObject.Find("enemy04").GetComponent<enemyAI>().facingRight && GameObject.Find("enemy04").GetComponent<enemyAI>().spotted) {
					shotTransform.localScale = new Vector2(-3, 3);
					move.direction = this.transform.right * -1;
				}
			}

			if (move != null) {
				
				if (!GameObject.Find("enemy05").GetComponent<enemyAI>().facingRight && GameObject.Find("enemy05").GetComponent<enemyAI>().spotted) { //determines if player is facing left & flips bullet sprite accordingly
					move.direction = this.transform.right; // towards in 2D space is the right of the sprite
					//shotTransform.localScale = new Vector2(-3, -3);
				}
				if (GameObject.Find("enemy05").GetComponent<enemyAI>().facingRight && GameObject.Find("enemy05").GetComponent<enemyAI>().spotted) {
					shotTransform.localScale = new Vector2(-3, 3);
					move.direction = this.transform.right * -1;
				}
			}
			
			
			//if(GameObject.Find("enemy03").GetComponent<enemyAI>().spotted) print("enemy3 spotted");
			
			 //>>>>>> something similar to the code below worked for the player to flip the bullet depending on which way they were facing, but i get a null reference exception error when i try to do the same thing for the enemy...
//			if (move != null) {
//				if (gameObject.GetComponent<enemyAI>().facingRight) { //determines if enemy is facing left & flips bullet sprite accordingly
//					move.direction = this.transform.right;
//				}
//				else {
//					shotTransform.localScale = new Vector2(-1, -1);
//					move.direction = this.transform.right * -1;
//				}
//			}
		}
	}

	public bool CanAttack {
		get {
			return shootCooldown <= 0f;
		}
	}
}