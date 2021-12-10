using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	
	[SerializeField]
	private GameObject player1Prefab;

	[SerializeField]
	private GameObject player2Prefab;

	[SerializeField]
	private GameObject playerSpawner;

	[SerializeField]
	private float playerRespawnTime = 3.0f;

	[SerializeField]
	private int Lives;
	private int[] playerLivesCount;

	void Start () {
		//playerSwawner is an empty gameobject that is just used to store the place where players should spawn and so that place can be easily moved in the editor.
		playerSpawner = GameObject.FindGameObjectsWithTag("PlayerSpawner")[0];
		//The array that's used to store the current lives during gameplay.
		playerLivesCount = new int[]{Lives, Lives};
	}

	//gets passed the playerID from PlayerCollision
	public IEnumerator PlayerSpawn (int i){
		//modifies the set number of lives and then checks to see if either player has reached 0 lives.
		--playerLivesCount[i];
		if (playerLivesCount[i] == 0){
			//there will eventually be a mothod that ends the game and transitions scenes here.
			print("endgame");
		}
		yield return new WaitForSeconds(playerRespawnTime);
		//if it's player 0, spawn them at the position. if it's player 1, spawn them at the inverse of the position and rotation.
		if (i == 0){
			Instantiate(player1Prefab, playerSpawner.transform.position, playerSpawner.transform.rotation);
		}
		else{
			Instantiate(player2Prefab, playerSpawner.transform.position *-1, Quaternion.Inverse(playerSpawner.transform.rotation));
		}
	}

	//used by the options in the starter scene.
	public void setLives(int i){
		Lives = i;
	}

	//used by playerCollision.
	public void StartRespawn(int i){
		StartCoroutine(PlayerSpawn(i));
	}
}
