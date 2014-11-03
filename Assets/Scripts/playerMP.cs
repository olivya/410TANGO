using UnityEngine;
using System.Collections;

public class playerMP : MonoBehaviour {
	
	public int maxMagic = 10;
	public int curMagic = 10;
	private float magicBarlength;
	private float maxMagicBarWidth = Screen.width / 2;
	public GUIStyle magicStyle;
	public float timeSinceLastMagicIncrease;
	
	// Use this for initialization
	void Start () {
		magicBarlength = maxMagicBarWidth;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - timeSinceLastMagicIncrease > 2) {
			AdjustCurMagic(1);
			timeSinceLastMagicIncrease = Time.time;
		}
		
	}
	
	void OnGUI() {
		GUI.Box(new Rect(10, 70, maxMagicBarWidth, 20), "" );
		
		GUI.Box(new Rect(10, 70, magicBarlength, 20), "" , magicStyle );
	}
	
	public void AdjustCurMagic (int adj) {
		curMagic += adj;
		if(curMagic < 0){
			curMagic = 0;
		}
		
		if(curMagic > maxMagic){
			curMagic = maxMagic;
		}
		
		if(maxMagic < 1){
			maxMagic = 1;
		}
		
		magicBarlength = (Screen.width / 2) * (curMagic / (float)maxMagic);
	}
	
	public bool enoughMagicToAttack() {
		return curMagic > 0;
	}	
}
