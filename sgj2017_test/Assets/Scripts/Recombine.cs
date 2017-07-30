using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recombine : MonoBehaviour {
	private GameObject[] lockButtons;
	private bool active = true;
	private Text text; 
	// Use this for initialization
	void Start () {
		text = GetComponentInChildren<Text>();
		lockButtons = GameObject.FindGameObjectsWithTag ("LockButton");
		GameState GS = GameState.getInstance();
		//GS.lastGameState.Count != 0
		for (int i=0; i<lockButtons.Length;i++) {
			if (GS.lastGameState.Count != 0) {
				lockButtons [i].GetComponent<Slot> ().initSlot (GS.lastGameState [i]);
			} else {
				lockButtons [i].GetComponent<Slot> ().initSlot (-1);
			}
		}
		saveGenome ();
	}
	public void toggleSlots(){
		active = !active;
		foreach (GameObject button in lockButtons) {
			if (!active) {
				text.text="STOP";
				button.GetComponent<Slot>().StartMachine(); 
			} else {
				text.text="Recombine";
				Slot s = button.GetComponent<Slot> (); 
				s.StopMachine ();
			}
		}
		if (active) {
			saveGenome ();
		}
	}
	void saveGenome(){
		//pobieram obrazek
		List<int> PlayerState = new List<int>();
		foreach (GameObject button in lockButtons) {
			Slot s = button.GetComponent<Slot> (); 
			PlayerState.Add(s.getSlotState ());
		}
		GameState GS = GameState.getInstance();
		GS.updatePlayerState(PlayerState);

		//Debug.Log (PlayerState.ToString());
		string verboseList="";
		foreach(int e in PlayerState){
			verboseList += ("|"+e.ToString ());
		}
		Debug.Log(verboseList);
		//Debug.Log(string.Join(" ", PlayerState));
	}

	// Update is called once per frame
	void Update () {
		
	}
}
