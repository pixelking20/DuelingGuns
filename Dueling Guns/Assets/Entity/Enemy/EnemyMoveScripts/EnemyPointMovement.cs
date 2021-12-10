using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointMovement : EnemyMove {

	private Vector3 destination;

	[SerializeField]
	private float waitTime = 5.0f;

	[SerializeField]
	private float heightBound = 0.9f;

	[SerializeField]
	private float approachOffset = 0.1f;

	private bool approach = true;

	protected override void Start () {
		base.Start();
		//randomly selects a destination in front of the enemy when it spawns.
		destination = new Vector3(transform.position.x, Random.Range(-heightBound, heightBound), 0);
	}
	protected override IEnumerator MovementLoop () {
		while (approach == true){
			//gets a vector pointing towards the destination
			Vector3 distance = destination - transform.position;
			//uses the size of the distance vector to simulate the ship slowing down as it approaches the destination point.
			transform.position += Time.deltaTime*distance*speedFactor;
			//Since the approach method is an infinite series, if the enemy is close enough to the point, it breaks the loop.
			if (distance.magnitude <= approachOffset){
				approach = false;
				Fire();
			}
			yield return new WaitForSeconds(0.05f);
		}
		//wait at the point for a set period of time and then fire when it starts leaving the screen.
		yield return new WaitForSeconds(waitTime);
		Fire();
		float velocity = 0f;
		while(true){
			//velocity is just a vector used to speed move the ship off the screen.
			transform.position +=transform.up*velocity*Time.deltaTime*speedFactor;
			//velocity has a constant acceleration of 1 unity unit per second.
			velocity+=Time.deltaTime;
			yield return new WaitForSeconds(0.05f);
		}
	}
}
