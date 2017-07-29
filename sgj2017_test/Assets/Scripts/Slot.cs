using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {
	private bool active = true;
	private Text text;
	private Button button;
	// Use this for initialization
	void Start () {
		text = GetComponentInChildren<Text> ();
		button = gameObject.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StartMachine(){
		button.interactable = false;
		
	} 
	public void StopMachine(){
	}
	public void ToggleSlotMachine(){
		active = !active;
		text.text = active ? "Free": "Locked";
	}
}
