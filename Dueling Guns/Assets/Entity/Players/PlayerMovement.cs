using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 0.25f;
	private float move;
	public float Boundries;

	void Update () {
		//move saves the players y position. The move is modified by a button press and then clamped so it doesn't go off screen.
		move += Input.GetAxis(this.tag) * speed * Time.deltaTime;
		move = Mathf.Clamp(move, -1*Boundries, Boundries);
		transform.position = new Vector2(transform.position.x, move);
	}
}
