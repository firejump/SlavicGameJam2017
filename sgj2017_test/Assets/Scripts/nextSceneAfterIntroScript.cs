using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextSceneAfterIntroScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("banditScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
	}
}
