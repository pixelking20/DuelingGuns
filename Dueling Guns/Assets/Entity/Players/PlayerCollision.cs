using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerIdentification))]
public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private PlayerSpawner PS;
    private int playerID;
    void Start(){
        //gets a reference to player spawner and it's own ID.
        PS = GameObject.FindWithTag("GameController").GetComponent<PlayerSpawner>();
        playerID = GetComponent<PlayerIdentification>().playerID;
    }
    void OnTriggerEnter2D(Collider2D c){
        //This collision controlls when the player needs to be spawned. It's here to the bullet doesn't have to ckeck if it collides with a player or an enemy or another bullet.
        PS.StartRespawn(playerID);
        Destroy(this.gameObject);
    }
}
