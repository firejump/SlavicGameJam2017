using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergeticAnimation : MonoBehaviour {
    public const float JUMP_DURATION = 0.75f;
    private float t0;

	// Use this for initialization
	void Start () {
        t0 = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float t = Time.time - t0;
        float p = Mathf.Repeat(t, JUMP_DURATION) / JUMP_DURATION;
        float h = -p * (p - 1);
        transform.position = new Vector3(0, h, 0);
	}
}
