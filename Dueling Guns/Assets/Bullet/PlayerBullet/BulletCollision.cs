using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    //both of these values are set when the bullet is spawned by the playerBulletController.
    public ScoreManager SM;
    public int OwnerID;

   void OnTriggerEnter2D(Collider2D c){
        //gets the point value of what ever object it's collided with and increments score with it and it's OwnerID
	    int points = c.gameObject.GetComponent<Score>().objectScore;
        SM.ScoreIncrement(OwnerID, points);
        //Destroys the object it's run into
        Destroy(c.gameObject);
        if (c.tag != "EnemyBullet")
            //if it's hit something other than an enemy bullet, it also destroys itself.
            Destroy(this.gameObject);
	}
}
