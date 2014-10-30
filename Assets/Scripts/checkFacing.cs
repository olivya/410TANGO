using UnityEngine;
using System.Collections;

public class checkFacing : MonoBehaviour {

	public bool facingRight;
	public bool noticed;
	public float distance;
	public float minDistance = 10;

	public Transform player;
	
	void Start () {
		facingRight = true;
		noticed = false;

	}

	void Update () {
		//GameObject player = GameObject.Find("player"); //first must give object reference so knows what game object to look for script on

		distance = transform.position.x - player.position.x;
		//print (distance);

		if (distance <= minDistance && distance > 0 && facingRight) {
			Flip ();
		}
		if (distance >= minDistance * -1 && distance < 0 && !facingRight) {
			Flip ();
		}

		if (distance >= minDistance * -1 && distance < 0 && facingRight) noticed = true;
		else if (distance <= minDistance && distance > 0 && !facingRight) noticed = true;
		else noticed = false;

		if (noticed) CancelInvoke();
		if (!noticed && !IsInvoking("Flip")) InvokeRepeating("Flip", 0f, Random.Range(1f,2f));
	}

	void Flip() {
		Vector3 theScale = transform.localScale; //get local scale...
		theScale.x *= -1; //...flip the x axis...
		transform.localScale = theScale; //...and  apply it back to local scale
		facingRight = !facingRight;
	}

}
