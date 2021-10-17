using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletControler : MonoBehaviour
{
    
    public GameObject bullet;
    public BulletMovement BMScript;
	public float reloadTime = 1.0f;
	private GameObject loadedBullet;
	private bool loaded = false;

    void Start(){
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
		transform.DetachChildren();
		StartCoroutine("Reload");
	}

	private IEnumerator Reload(){
		yield return new WaitForSeconds(reloadTime);
		loadedBullet = Instantiate(bullet, transform.position, transform.rotation);
		loadedBullet.transform.SetParent(this.transform);
		loadedBullet.tag = this.tag;
		loaded = true;
	}
}
