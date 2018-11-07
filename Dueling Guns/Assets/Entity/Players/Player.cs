using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

	public float speed = 0.25f;
	private float move;

	public GameObject bullet;
	public float reloadTime = 1.0f;

	private float reloadTimer = 0f;
	private GameObject loadedBullet;

	void Start () {
		base.Start();
	}

	void Update () {

		//movement code
		move = Input.GetAxis(this.tag) * speed * Time.deltaTime;
		print("move value:" + move);
		transform.Translate(new Vector2(move,0));

		//bullet firing code
		if (Input.GetAxis(this.tag + "Fire") != 0f)
			this.fire();

		if (loadedBullet != null){}
		else if (reloadTimer > 0f)
			reloadTimer -= Time.deltaTime;
		else {
			loadedBullet = Instantiate(bullet, transform.position, transform.rotation);
			loadedBullet.transform.SetParent(this.transform);
			loadedBullet.tag = tag;
			reloadTimer = reloadTime;
		}
	}

	public void fire(){
		transform.DetachChildren();
		loadedBullet = null;
	}
}
