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
	void Awake () {
		text = GetComponentInChildren<Text> ();
		button = gameObject.GetComponent<Button> ();
		imgs = GetComponentsInChildren<SpriteChanger> ();
		//initSlot ();
	}
	public void initSlot(int frame){
		if (frame!=-1) {
			imgs [0].SetImg (frame);
		} else {
			imgs[0].SetImg();	
		}
	}


	public void StartMachine(){
		button.interactable = false;
		if (active) {
				imgs[0].StartCoroutines();
		}
	} 
	public int getSlotState(){
		return imgs.Length!=0 ? imgs [0].rng : 0;
	}
	public void StopMachine(){
		button.interactable = true;
		if (active) {
			imgs[0].StopCoroutines ();
		}
	}

	public void ToggleSlotMachine(){
		active = !active;
		text.text = active ? "Free": "Locked";

	}
}
