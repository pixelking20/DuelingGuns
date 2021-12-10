using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPorcupineFire : EnemyFire
{
    [SerializeField]
    private int bulletCount;

    private Quaternion starterRotation = Quaternion.Euler(0,0,-90);

    //rotation offset is the rotation around the player that the next bullet needs to be spawned.
    private Quaternion rotationOffset;

    protected override void Start(){
        base.Start();
        //it takes the full 360 degrees around the player and cuts it into a number of segments equal to the number of bullets that need to be fired.
        rotationOffset = Quaternion.Euler(0,0,360/bulletCount);
    }
    public override void Fire(){
        Vector3 objectoffsetDirection = spawnOffsetScale * this.transform.up;
        Vector3 objectPosition = this.transform.position;
        for (int i = 0; i<bulletCount; i++){
            //for each bullet, it's position is equal to the player position plus an offset vector that is rotationed by the starterRotation.
            Vector3 tempPosition = objectPosition + (starterRotation * objectoffsetDirection);
            Instantiate(bulletPrefab, tempPosition, starterRotation);
            //The startRotation is then updated by the rotation segment. It uses StarterRotation so another Quaternion doesn't have to be made.
            starterRotation *= rotationOffset;
        }
    }
    
}
