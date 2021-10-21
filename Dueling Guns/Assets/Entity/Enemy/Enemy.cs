using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Vector2 destonation;
	public float stayTime = 5.0f;

	// Use this for initialization
	void Start () {
		destonation = new Vector2(Random.value * 2.6f - 1.3f, Random.value - 0.5f);
		if (Random.value > 0.5)
			transform.position = new Vector2(destonation.x, destonation.y-2);
		else
			transform.position = new Vector2(destonation.x, destonation.y+2);
	}

	// Update is called once per frame
	void Update () {

	}
}
