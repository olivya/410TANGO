using UnityEngine;
using System.Collections;

public class EnemyAINew : MonoBehaviour {
	
	Animator enemyAnim;
	public bool noticed;
	public bool facingRight;
	public bool tooClose;
	float distance;
	public float speed = 3f;

	public string enemyName = "enemy#";

	
	void Start () {
		enemyAnim = GetComponent<Animator>();
		tooClose = false;
		enemyAnim.SetFloat("Speed", 0);
		GameObject enemy;
	}
	
	void Update () {
		GameObject enemy = GameObject.Find(enemyName);
		noticed = enemy.GetComponent<checkFacing>().noticed;
		facingRight = enemy.GetComponent<checkFacing>().facingRight;
		distance = enemy.GetComponent<checkFacing>().distance;
		
		//GameObject player = GameObject.Find("player"); 
		//distance = player.GetComponent<playerController>().distance;
		
		if (noticed && facingRight && !tooClose) {
			transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
			enemyAnim.SetFloat("Speed", Mathf.Abs(speed));
			//print (enemyName + " noticed");
		}
		
		if (noticed && !facingRight && !tooClose) {
			transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
			enemyAnim.SetFloat("Speed", Mathf.Abs(speed));
			print (enemyName + " noticed");
		}
		
		if (Mathf.Abs (distance) < 2) {
			tooClose = true;
			enemyAnim.SetFloat("Speed", 0);
		}
		
		else tooClose = false;
		
		if (!tooClose && !noticed) {
			enemyAnim.SetFloat ("Speed", 0);
		}
	}
}
