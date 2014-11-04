using UnityEngine;
using System.Collections;

public class pauseScreen : MonoBehaviour {

	public bool paused = false;

	void Update() {

	}

	void OnGUI() {

		if(GUI.Button(new Rect(1835,20,80,20),"Pause"))
		{
			paused = true;
		}
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			paused = true;
		}
		if(paused == true)
		{
			GUI.Box(new Rect(810,75,300,400),"Menu");

			if(GUI.Button(new Rect(920,100,80,20),"Resume"))
			{
				paused = false;
			}
			if(GUI.Button(new Rect(920,130,80,20),"Main Menu"))
			{
				Application.LoadLevel(0);
			}
		}
		if(paused == true)
		{
			Time.timeScale = 0;
		}
		if(paused == false )
		{
			Time.timeScale = 1;
		}
	}
}