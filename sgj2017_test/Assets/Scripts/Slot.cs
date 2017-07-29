using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {
	private bool active = true;
	private Text text;
	private Button button;
	private SpriteChanger[] imgs;
	// Use this for initialization
	void Start () {
		text = GetComponentInChildren<Text> ();
		button = gameObject.GetComponent<Button> ();
		imgs = GetComponentsInChildren<SpriteChanger> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StartMachine(){
		button.interactable = false;
		foreach (SpriteChanger img in imgs) {
			img.StartCoroutines();
		}
	} 
	public int getSlotState(){
		return imgs.Length!=0 ? imgs [0].rng : 0;
	}
	public void StopMachine(){
		button.interactable = true;
		foreach (SpriteChanger img in imgs) {
			img.StopCoroutines();
		}
	}

	public void ToggleSlotMachine(){
		active = !active;
		text.text = active ? "Free": "Locked";

	}
}
