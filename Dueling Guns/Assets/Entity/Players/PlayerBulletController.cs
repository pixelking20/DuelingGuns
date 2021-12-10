using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerIdentification))]
public class PlayerBulletController : MonoBehaviour
{
    
	[SerializeField]
    private GameObject bullet;
	private float reloadTime = 1.0f;

	public float bulletSpeed = 1.5f;
	private GameObject loadedBullet;
	private bool loaded = false;

	private ScoreManager SM;
	private int playerID;

    void Start(){
		//gets the player ID and scoreManager. Both of these are passed to the bullet when it's instantiated.
		playerID = GetComponent<PlayerIdentification>().playerID;
		SM = GameObject.FindWithTag("GameController").GetComponent<ScoreManager>();
		StartCoroutine("Reload");
	}
	
	void Update()
    {
        //if the bullet is loaded and the fire button is pressed, the bullet will fire
		if (loaded && Input.GetAxis(this.tag + "Fire") != 0f){
			loaded = false;
			this.fire();
		}
    }

    public void fire(){
		//The bullet move script is added so the bulletmovement script doesn't have to check a bool for it it's fired or not.
		BulletMovement BMTemp = loadedBullet.AddComponent<BulletMovement>();
		BMTemp.speed = bulletSpeed;
		//breaks the parent relationship so the bullet no longer moves up or down with the player.
		loadedBullet.transform.parent = null;
		StartCoroutine("Reload");
	}

	//the reason for the coroutine is so it can use the WaitForSeconds with the reloadTime of the player.
	private IEnumerator Reload(){
		yield return new WaitForSeconds(reloadTime);
		loadedBullet = Instantiate(bullet, transform.position, transform.rotation);
		//sets the parent so it moves up and down with the player before it's fired.
		loadedBullet.transform.SetParent(this.transform);
		//sets the player to the players layer so that the player and their own bullet don't collide with each other since the collision matrix has been modified.
		loadedBullet.layer = this.gameObject.layer;
		//gives the presaved references from the start method 
		BulletCollision BCTemp = loadedBullet.GetComponent<BulletCollision>();
		BCTemp.OwnerID = this.playerID;
		BCTemp.SM = SM;
		//sets loaded so that the update method can fire the weapon again
		loaded = true;
	}
}
