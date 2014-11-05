using UnityEngine;
using System.Collections;

public class scrollScript : MonoBehaviour {

	public float speed = 0;
	float dir;
	//public Transform camera;

	// Use this for initialization
	void Start () {
		//GameObject player;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find("player");
		float move = player.GetComponent<playerController>().move;



		if (move > 0) dir = 1;
		if (move < 0) dir = -1;

		//bool movingLeft = player.GetComponent<playerController>().movingLeft;
//
//		if (movingRight){
		renderer.material.mainTextureOffset = new Vector2 (renderer.material.mainTextureOffset.x + move * speed, 0f);
		print (renderer.material.mainTextureOffset.x);
//			print ("moving right");
//		}

//		if (movingLeft) {
//			renderer.material.mainTextureOffset = new Vector2 ((Time.time * -speed)%1, 0f);
//			print ("moving left");
//		}

//		else {
//			renderer.material.mainTextureOffset = new Vector2 (0f, 0f);
//		}
	}
}
