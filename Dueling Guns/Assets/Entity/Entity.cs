using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	public int score;
	public GameObject GameController;
	public GameController GC;

	public Rigidbody2D rb2D;

	protected void Start () {

		GameController = GameObject.FindGameObjectsWithTag("GameController")[0];
		GC = GameController.GetComponent<GameController>();
		rb2D = GetComponent<Rigidbody2D>();
	}

	//collision
	void OnTriggerEnter2D(Collider2D c){
		//print("collision on Entity");
		if (c.gameObject.tag != this.gameObject.tag){
		 	if (c.gameObject.tag == "Player1")
				GC.player1Score += score;
			if (c.gameObject.tag == "Player2")
				GC.player2Score += score;
			Destroy(this.gameObject);
		}
	}
}
