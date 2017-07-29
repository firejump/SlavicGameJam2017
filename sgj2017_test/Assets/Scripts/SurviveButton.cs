using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurviveButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Survive(){
		GameState GS = GameState.getInstance();
		GS.startTowerDefense ();
	}
}
