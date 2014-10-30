using UnityEngine;
using System.Collections;

public class enemyHp : MonoBehaviour {
	
	public int maxHealth = 3; //HP
	public bool isEnemy = true; //(this object is enemy)

	public int curHealth = 3; 
	public float gearCount = 0;
	public Vector3 screenPosition;
	public Transform target;
	private float healthBarlength;

	//initialization
	void Start () {
		healthBarlength = Screen.width / 8;
		//gearCount=0;
	}
	
	//called once per frame
	void Update () {
		AdjustcurHealth (0);

		screenPosition = Camera.main.WorldToScreenPoint(target.position);
		screenPosition.y = Screen.height - screenPosition.y;
	}

	void OnGUI() {
		if (gameObject.GetComponent<enemyAI>().spotted || curHealth != 3) //displays health if spotted OR if enemy has already taken damage
			GUI.Box(new Rect(screenPosition.x-55, screenPosition.y-60, healthBarlength, 20), curHealth + "/" + maxHealth);
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
		if(curHealth == 0) {
			Destroy(gameObject);
			gearCount=gearCount+1;
			print("gear count: "+gearCount);
			//gameObject.renderer.enabled = false;
			//gameObject.active = false;
			//Destroy(hit.collider.gameObject);
			//active = false;
		}
	}

	//(check collision and makes AdjustcurHealth int = 1, and minus from curHealth)
	void OnTriggerEnter2D(Collider2D collider) {
		//Is this a shot?
		shotScript shot = collider.gameObject.GetComponent<shotScript>(); //variable of type shotScript that is called shot, setting it to whether the object that collided has a shotScript or not
		if(shot != null) {
			//avoid friendly fire
			if (shot.isEnemyShot != isEnemy) {
				AdjustcurHealth(-1);
				//destroy the shot
				//remember to always target the game object, otherwise you will just remove the script
				Destroy(shot.gameObject);
			}
		}
	}
}
