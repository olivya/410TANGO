using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour {
	
	//public Transform target;//set target from inspector instead of looking in Update
	public float speed = 3f;
	
	public Transform sightStart, sightEnd; //start & end positions of raycast
	public bool spotted = false; //whether the enemy has seen the player
	
	public Transform nearStart, nearEnd;
	public bool tooClose = false;
	
	//public bool shootRight;
	
	public bool facingRight = true;
	
	Animator enemyAnim;
	
	void Start() {
		enemyAnim = GetComponent<Animator>();
		if(!spotted) InvokeRepeating("Patrol", 0f, Random.Range(1f,2f)); //at 0 secs (when game starts), patrol is called, and every 2-6 seconds from then on, patrol is called again
		//shootRight = true;
	}
	
	void Update()
	{
		Raycasting();
		Behaviours();
		//
		//		if (transform.localScale.x > 0)
		//			shootRight = true;
		//		if (transform.localScale.x < 0)
		//			shootRight = false;
	}
	
	void Raycasting()
	{
		Debug.DrawLine(sightStart.position, sightEnd.position, Color.magenta); //draw raycast in Scene view so you can see where it is
		spotted = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player")); //if raycast is hitting a player, 'spotted' turns to true; last bit is so enemy only spots player, not themselves
		
		Debug.DrawLine(nearStart.position, nearEnd.position, Color.green);
		tooClose = Physics2D.Linecast(nearStart.position, nearEnd.position, 1 << LayerMask.NameToLayer("Player"));
	}
	
	void Behaviours()
	{
		if(spotted && facingRight && !tooClose){
			transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
			//enemyAnim.SetFloat("Speed", Mathf.Abs(speed));
		}
		if(spotted && !facingRight && !tooClose){
			transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
			//enemyAnim.SetFloat("Speed", Mathf.Abs(speed));
		}
		else enemyAnim.SetFloat("Speed", 0);
		
		if(spotted)
		{
			enemyAnim.SetFloat("Speed", Mathf.Abs(speed));
			CancelInvoke();
		}
		
		if(!spotted && !IsInvoking("Patrol"))
			InvokeRepeating("Patrol", 0f, Random.Range(1f,2f));
		
		if(tooClose) enemyAnim.SetFloat("Speed", 0);
	}
	
	void Patrol()
	{	
		facingRight = !facingRight; //shorthand for: "if the boolean is true, set it to false, and vice versa"
		
		if(facingRight)
		{
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
		else
		{
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
	
}