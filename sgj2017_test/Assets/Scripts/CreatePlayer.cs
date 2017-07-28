using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject playerPlaceholder = gameObject;
        GameObject playerModel = GameState.getInstance().getPlayerState().createPlayerObject();
        playerModel.transform.SetParent(playerPlaceholder.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
