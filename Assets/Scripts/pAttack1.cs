using UnityEngine;
using System.Collections;

public class pAttack1 : MonoBehaviour {

	public GameObject target;
	public Transform atkStart, atkEnd; //start & end positions of raycast
	public bool atkRange = false; //whether the enemy is in attack range

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Raycasting ();
		Behaviours ();

		if (atkRange && Input.GetKeyUp(KeyCode.Space)) {
			Attack();
			print ("closerange");
		}

	}
	void Raycasting(){
		Debug.DrawLine (atkStart.position, atkEnd.position, Color.blue);
		atkRange = Physics2D.Linecast(atkStart.position, atkEnd.position, 1 << LayerMask.NameToLayer("Enemy"));
	}

	public void Attack(){
		enemyHp eh = (enemyHp)target.GetComponent ("enemyHp");
		eh.AdjustcurHealth (-1);
	}

	void Behaviours(){

	}
}
