using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySingleFire : EnemyFire
{
    public override void Fire(){
        //gets the enemies position and a vector the length of the spawn Offset
        Vector3 direction = this.transform.right * spawnOffsetScale;
        Vector3 basePosition = this.transform.position;
        //gets a rotation that is 90 degrees from the front of the enemy
        Quaternion rotation = Quaternion.Euler(0,0,-90);
        //spawns a bullet to it's right and to it's inverse of right.
        Instantiate(bulletPrefab, basePosition + direction, rotation);
        Instantiate(bulletPrefab, basePosition - direction, Quaternion.Inverse(rotation));
    }
    
}
