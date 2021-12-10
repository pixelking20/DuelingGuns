using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

	public float speed;

	//added by playerBulletController when the bullet is fired.
	void Update () {
			transform.position += transform.up * speed * Time.deltaTime;
	}
}
