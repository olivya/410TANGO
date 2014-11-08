using UnityEngine;
using System.Collections;

public class killSelf : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("player").GetComponent<playerHp>().respawned) {				
			Destroy (gameObject);
		}
	
	}
}
