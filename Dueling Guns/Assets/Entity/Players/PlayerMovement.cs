using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 0.25f;
	private float move;
	public float Boundries;

	void Update () {

		//Modifies the move value every frame that the move button is pressed
		move += Input.GetAxis(this.tag) * speed * Time.deltaTime;
		//clamps the player between the positive and negative values of Boundries
		move = Mathf.Clamp(move, -1*Boundries, Boundries);
		//Assigns the move value to the y-value of the player
		transform.position = new Vector2(transform.position.x, move);

	}
}
