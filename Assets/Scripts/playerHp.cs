using UnityEngine;
using System.Collections;

public class playerHp : MonoBehaviour {
	
	public int maxHealth = 10;
	public int curHealth = 10;
	private float healthBarlength;
	public bool isEnemy = false; // // // // added not an enemy<<<<<<<<<<<<<new
	float gearCount;
	private float maxHealthBarWidth = Screen.width / 2;
	public GUIStyle healthStyle;
	// Use this for initialization
	void Start () {
		healthBarlength = maxHealthBarWidth;
		
		//GameObject gearCount = gearCount.GetComponent<enemyHp>();
		//enemyHp enemyHp = enemyHp.GetComponent<gearCount>();
		
	}
	
	// Update is called once per frame
	void Update () {
		AdjustcurHealth (0);
	}
	
	void OnGUI() {
		GUI.Box(new Rect(10, 10, maxHealthBarWidth, 20), "" );
		
		GUI.Box(new Rect(10, 10, healthBarlength, 20), "" , healthStyle );
		
		//float gearCount = gameObject.GetComponent<enemyHp>().gearCount;
		//GUI.Box (new Rect (10, 20, Screen.width / 12, 20), "Gears: " + gearCount); //+ gameObject.GetComponent<enemyHp>().gearCount);
	}
	
	public void AdjustcurHealth (int adj) {
		curHealth += adj;
		if(curHealth < 0){
			curHealth = 0;
		}
		if(curHealth > maxHealth){
			curHealth = maxHealth;
		}
		if(maxHealth < 1){
			maxHealth = 1;
		}
//		if(curHealth == 0 || transform.position.y <= -3) {
//			//Destroy(gameObject);
//			Application.LoadLevel("PROTOTYPE01");
//		}

		if(transform.position.y <= -3) {
			transform.position = GetComponent<checkPoint>().spawnPoint.position;
			AdjustcurHealth(-1);
			//Application.LoadLevel("PROTOTYPE01");
		}
		if(curHealth == 0) {
			transform.position = GetComponent<checkPoint>().spawnPoint.position;
			curHealth = 10;
			//Application.LoadLevel("PROTOTYPE01");
		}

		healthBarlength = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}
	
	
	//added collision detect so lose hp when hit by enemy bullet<<<<<<<<<<<<<<new
	void OnTriggerEnter2D(Collider2D collider) {
		// Is this a shot?
		enemyShotScript shot = collider.gameObject.GetComponent<enemyShotScript>();
		potionHeal healed = collider.gameObject.GetComponent<potionHeal> ();
		
		if (shot != null) {
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy) {
				AdjustcurHealth(-1);
				// Destroy the shot
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
		
		if (healed) {
			AdjustcurHealth(1);
			Destroy(healed.gameObject);
		}
	}
}
