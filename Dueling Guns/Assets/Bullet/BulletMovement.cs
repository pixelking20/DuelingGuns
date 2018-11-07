using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

	public float speed = 0.5f;

	void Start () {

	}

	protected void Update () {
		if (transform.parent == null)
			transform.position += transform.up * speed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D c){
		//print("collision on bullet");
		print(c.gameObject.tag);
		print(this.gameObject.tag);
		if (c.gameObject.tag != this.gameObject.tag){
			Destroy(this.gameObject);
		}
	}
}
