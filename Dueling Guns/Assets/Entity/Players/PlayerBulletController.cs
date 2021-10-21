using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerIdentification))]
public class PlayerBulletController : MonoBehaviour
{
    
    public GameObject bullet;
	public float reloadTime = 1.0f;

	public float bulletSpeed = 1.5f;
	private GameObject loadedBullet;
	private bool loaded = false;

	private ScoreManager SM;
	private delegate void scoreDelegate(int x, int i);
	private int playerID;

    void Start(){
		playerID = GetComponent<PlayerIdentification>().playerID;
		SM = GameObject.FindWithTag("GameController").GetComponent<ScoreManager>();
		StartCoroutine("Reload");
	}
	
	void Update()
    {
        //bullet firing code
		if (loaded && Input.GetAxis(this.tag + "Fire") != 0f){
			loaded = false;
			this.fire();
		}
    }

    public void fire(){
		BulletMovement BMTemp = loadedBullet.AddComponent<BulletMovement>();
		BMTemp.speed = bulletSpeed;
		loadedBullet.transform.parent = null;
		StartCoroutine("Reload");
	}

	private IEnumerator Reload(){
		yield return new WaitForSeconds(reloadTime);
		loadedBullet = Instantiate(bullet, transform.position, transform.rotation);
		loadedBullet.transform.SetParent(this.transform);
		loadedBullet.layer = this.gameObject.layer;
		BulletCollision BCTemp = loadedBullet.GetComponent<BulletCollision>();
		BCTemp.OwnerID = this.playerID;
		BCTemp.SM = SM;

		loaded = true;
	}
}
