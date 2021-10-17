using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	

	public GameObject player1Prefab;
	public GameObject player2Prefab;

	public GameObject playerSpawner;

	public float playerRespawnTime = 3.0f;

	private int Lives;
	private int[] LivesCount;

	void Start () {
		playerSpawner = GameObject.FindGameObjectsWithTag("PlayerSpawner")[0];
		LivesCount = new int[]{Lives, Lives};
	}

	IEnumerator PlayerSpawn (int i){
		if (LivesCount[i] == 0){
			//endgame
		}
		else
			--LivesCount[i];
		yield return new WaitForSeconds(playerRespawnTime);
		if (i == 0){
			Instantiate(player1Prefab, playerSpawner.transform.position, playerSpawner.transform.rotation);
		}
		else{
			Instantiate(player1Prefab, playerSpawner.transform.position *-1, Quaternion.Inverse(playerSpawner.transform.rotation));
		}
	}
	public void setLives(int i){
		Lives = i;
	}
}
