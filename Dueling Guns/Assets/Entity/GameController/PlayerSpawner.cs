using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	

	public GameObject player1Prefab;
	public GameObject player2Prefab;

	public GameObject playerSpawner;

	public float playerRespawnTime = 3.0f;

	[SerializeField]
	private int Lives;
	private int[] LivesCount;

	void Start () {
		playerSpawner = GameObject.FindGameObjectsWithTag("PlayerSpawner")[0];
		LivesCount = new int[]{Lives, Lives};
	}

	public IEnumerator PlayerSpawn (int i){
		print("coroutine started");
		--LivesCount[i];
		if (LivesCount[i] == 0){
			print("endgame");
		}
		print("wait called");
		print(Time.timeScale);
		yield return new WaitForSeconds(playerRespawnTime);
		print("wait ended");
		if (i == 0){
			Instantiate(player1Prefab, playerSpawner.transform.position, playerSpawner.transform.rotation);
			print("Player1 spawned");
		}
		else{
			Instantiate(player2Prefab, playerSpawner.transform.position *-1, Quaternion.Inverse(playerSpawner.transform.rotation));
			print("Player2 spawned");
		}
	}
	public void setLives(int i){
		Lives = i;
	}

	public void StartRespawn(int i){
		StartCoroutine(PlayerSpawn(i));
	}
}
