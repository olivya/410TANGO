﻿//this script controls cool down on the shooting and instantiates prefab

using UnityEngine;

public class windAtkScript : MonoBehaviour {
	
	public Transform shotPrefab;
	public float shootingRate = 0.5f;
	
	private float shootCooldown;
	
	
	//	public bool shootingLeft;
	
	
	void Start() {
		shootCooldown = 0f;
	}
	
	void Update() {
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}
	}
	public void Attack (bool isEnemy)
	{
		playerMP pmp = gameObject.GetComponent<playerMP> (); 
		if(pmp.enoughMagicToAttack()) {
			doAttack(isEnemy);
		}
	}
	
	public void doAttack(bool isEnemy)
	{
		playerMP pmp = gameObject.GetComponent<playerMP> ();
		pmp.AdjustCurMagic (-1);
		
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			
			// Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;
			
			// Assign position
			shotTransform.position = transform.position;
			
			// The is enemy property
			shotScript shot = shotTransform.gameObject.GetComponent<shotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
			
			// Make the weapon shot always towards it
			moveScript move = shotTransform.gameObject.GetComponent<moveScript>();
			
			if (move != null) {
				if (gameObject.GetComponent<playerController>().facingRight) { //determines if player is facing left & flips bullet sprite accordingly
					move.direction = this.transform.right; // towards in 2D space is the right of the sprite
				}
				else {
					shotTransform.localScale = new Vector2(-1, -1);
					move.direction = this.transform.right * -1;
				}
			}
		}
	}
	
	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}


