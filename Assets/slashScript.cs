using UnityEngine;
using System.Collections;

public class slashScript : MonoBehaviour {
	
	public int damage = 1;
	
	public bool isEnemyShot = false;
	
	void Start () {
		Destroy (gameObject, 0.5f);
	}
}
