﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {
    public string handler = "";

    private Dictionary<string, ObstacleHandler> HANDLERS = new Dictionary<string, ObstacleHandler>()
    {
        { "ravine", new RavineHandler() },
        { "flower", new FlowerHandler() },
        { "darkness", new DarknessHandler() },
        { "slope", new SlopeHandler() }
    };

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        ObstacleHandler handlerObject = HANDLERS[handler];
        UnityEngine.Debug.Log("CHECK!");
        if (handlerObject.check())
        {
            UnityEngine.Debug.Log("GAME OVER");
            handlerObject.onHit(this);
            GameState.getInstance().gameOver = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
