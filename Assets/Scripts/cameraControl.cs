using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {

	public Transform target;
	public float heightLimit = 5;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//print (target.position.y);

		Vector3 position = transform.position;
		position.x = target.position.x;
		transform.position = position;

		if (target.position.y > heightLimit) { //	transform.position = position;&& gameObject.GetComponent<playerController> ().grounded) {
			position.y = target.position.y * 0.7f; //- target.position.y * 0.3f;
			transform.position = position;
		}

//		if(resetCam) {
//			position.y = target.position.y; //- target.position.y * 0.3f;
//			transform.position = position;
//		}

		//
		//		if (gameObject.GetComponent<playerController>().grounded) {
//				position.y = target.position.y - target.position.y * 0.3f;
//				position.x = target.position.x;
//
//				transform.position = position;
//			}
//			
//			else {
//				position.y = target.position.y - target.position.y * 0.3f;
//				position.x = target.position.x; 
//
//				transform.position = position;
//			}
//		}
	}
}