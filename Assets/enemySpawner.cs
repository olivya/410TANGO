using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {
	
	//public float spawnTime = 5f;		// The amount of time between each spawn.
	//public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject enemies;		// Array of enemy prefabs.
	
	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		//InvokeRepeating("Spawn", spawnDelay, spawnTime);
		Invoke ("Spawn", 1);
	}

	void Update (){
		playerHp other = GetComponent<playerHp>();
		if (other.curHealth == 0) {
			Invoke ("Spawn", 1);
		}
	}
	
	void Spawn ()
	{
		// Instantiate a random enemy.
		//int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies, transform.position, transform.rotation);
	}
}