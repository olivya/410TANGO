using UnityEngine;

//same as shotScript, made another one for enemy so it doesnt affect player

public class enemyShotScript : MonoBehaviour {
	public bool isEnemyShot = false;
	
	void Start() {
		Destroy(gameObject, 2);
	}
}
