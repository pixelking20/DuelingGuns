using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public ScoreManager SM;
    public int OwnerID;

   void OnTriggerEnter2D(Collider2D c){
	    int points = c.gameObject.GetComponent<Score>().objectScore;
        SM.ScoreIncrement(OwnerID, points);
        Destroy(c.gameObject);
        print("Destroy Called");
        if (c.tag != "EnemyBullet")
            Destroy(this.gameObject);
	}
}
