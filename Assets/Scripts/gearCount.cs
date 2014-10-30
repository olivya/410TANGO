using UnityEngine;
using System.Collections;

public class gearCount : MonoBehaviour {
	
	public int gearCounter = 0;

	// Use this for initialization
	void Start () {
	
	}

	void OnGUI() {
		GUI.Box (new Rect (10, 40, Screen.width / 8, 20), "Gears:" + gearCounter);
	}

	// Update is called once per frame
	void Update () {
		AdjustgearCount (0);
	
	}

	public void AdjustgearCount (int adj) {
		gearCounter += adj;
		if(gearCounter < 0){
			gearCounter = 0;
		}
	}
	void OnTriggerEnter2D(Collider2D collider) {
		getGear obtained = collider.gameObject.GetComponent<getGear> ();

			if (obtained) {
				AdjustgearCount(1);
				// Destroy the shot
				Destroy(obtained.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
}
