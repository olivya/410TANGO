#pragma strict

function Start () {

}

function Update () {
		transform.position = Vector3(Mathf.PingPong(Time.time * 2, 3), transform.position.y, transform.position.z);
	}
 