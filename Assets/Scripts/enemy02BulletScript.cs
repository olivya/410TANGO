using UnityEngine;

// newly created weapon gameobject to rotate around to shoot in different direction instead of player (according to tutorial)

public class enemy02BulletScript : MonoBehaviour {
	
	private enemyBulletAtkScript[] weapons;
	
	void Awake() {
		weapons = GetComponentsInChildren<enemyBulletAtkScript>(); // Retrieve the weapon only once from child object script
	}
	
	void Update() {
		
		if (GameObject.Find ("enemy02").GetComponent<enemyAI> ().spotted) { //check from gameobject "enemy" and its script "enemyAI for if spotted = true
			foreach (enemyBulletAtkScript weapon in weapons) {
				if (weapon != null && weapon.CanAttack) { // Auto-fire
					weapon.Attack(true);
				}
			}
		}
	}
}