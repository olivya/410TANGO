using UnityEngine;
using System.Collections;

public class triggerLever : MonoBehaviour {

	public GameObject target;
	public GameObject leverSwitch;
	
	void OnTriggerEnter2D(Collider2D collider) {
		leverTrigger triggered = collider.gameObject.GetComponent<leverTrigger> ();
		
		if (triggered) {
			//flipSwitch();
			Destroy(target);
			if (target != null){
				flipSwitch ();
			}
		}
	}

	void flipSwitch(){
		Vector3 theScale = leverSwitch.transform.localScale; //get local scale...
		theScale.x *= -1; //...flip the x axis...
		leverSwitch.transform.localScale = theScale;
		}
}