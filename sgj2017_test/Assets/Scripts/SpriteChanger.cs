using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour {

	[HideInInspector]
	public int rng;
	public float waitTime=0.06f;
	private IEnumerator coroutineRef;
	private int noElems=13;

	void Awake () {
	}

	// Use this for initialization
	void SetImg(){
		//for int min [inclusive] and max [exclusive] for float inclusive on both ends
		int rand = Random.Range (1, noElems);
		//losowanie bez powtorzen
		rng = rand == rng ? (rand + 1) % (noElems-1) : rand; 
		//filenames are in range 000.png - 012.png
		string filename = rng.ToString ().PadLeft (3, '0');
		Sprite spr = Resources.Load<Sprite>("Sprites/"+ filename);
		//Debug.Log (spr);
		GetComponent<Image>().sprite  = spr;			
	}



	IEnumerator MyCoroutine(float waitTime){
		//http://www.unitygeek.com/coroutines-in-unity3d/
		Debug.Log("cr"); 
		//yield return null; // resumes after all update() on the next frame
		while (true){
			yield return new WaitForSeconds(waitTime); // resumes after all update() on the next frame 
			SetImg();
		}
	}
	void StopCoroutines(){
		StopCoroutine (coroutineRef);
	}

	void Start () {
		SetImg ();
		coroutineRef=MyCoroutine(waitTime);
		StartCoroutine (coroutineRef);
	}

	// Update is called once per frame
	void Update () {
	}

	void OnDestroy(){
		StopCoroutines ();
	}
}

