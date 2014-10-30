using UnityEngine;
using System.Collections;

public class checkPoint : MonoBehaviour {
	public Transform spawnPoint;
	
	void OnTriggerEnter2D(Collider2D collider) {
		pointReached saved = collider.gameObject.GetComponent<pointReached> ();
		
		if (saved) {
			spawnPoint.position = new Vector2(transform.position.x, transform.position.y);
			print(transform.position.x + " , " + transform.position.y);
			//spawnPoint.position = transform.position;
			//Destroy(saved.gameObject); // Remember to always target the game object, otherwise you will just remove the script
		}
	}
}