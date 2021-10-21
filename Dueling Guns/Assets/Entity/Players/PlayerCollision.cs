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
        PS = GameObject.FindWithTag("GameController").GetComponent<PlayerSpawner>();
        playerID = GetComponent<PlayerIdentification>().playerID;
    }
    void OnTriggerEnter2D(Collider2D c){
        PS.StartRespawn(playerID);
        Destroy(this);
    }
}
