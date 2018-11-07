using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int player1Score = 0;
	public int player2Score = 0;

	public GameObject player1Prefab;
	public GameObject player2Prefab;
	public GameObject enemyPrefab;

	public GameObject player1Spawner;
	public GameObject player2Spawner;

	public GameObject player1;
	public GameObject player2;
	public GameObject[] enemies;

	public float player1RespawnTime = 3.0f;
	public float player2RespawnTime = 3.0f;

	private float player1RespawnTimer = 3.0f;
	private float player2RespawnTimer = 3.0f;

	void Start () {
		player1Spawner = GameObject.FindGameObjectsWithTag("Player1Spawn")[0];
		player2Spawner = GameObject.FindGameObjectsWithTag("Player2Spawn")[0];
		player1 = GameObject.FindGameObjectsWithTag("Player1")[0];
		player2 = GameObject.FindGameObjectsWithTag("Player2")[0];
	}

	// Update is called once per frame
	void Update () {
		if(player1 == null){
			if (player1RespawnTimer >= 0){
				player1RespawnTimer -= Time.deltaTime;
			}
			else{
				player1 = Instantiate(player1Prefab, player1Spawner.transform.position, player1Spawner.transform.rotation);
				player1RespawnTimer = player1RespawnTime;
			}
		}

		if(player2 == null){
			if (player2RespawnTimer >= 0){
				player2RespawnTimer -= Time.deltaTime;
			}
			else{
				player2 = Instantiate(player2Prefab, player2Spawner.transform.position, player2Spawner.transform.rotation);
				player2RespawnTimer = player2RespawnTime;
			}
		}

		if (Input.GetKey("escape"))
			Application.Quit();
	}
}
