using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the abstract class that defines all of the different types of firing patterns. It's designed as an abstract call so that each firing type can be drag and drop in the editor.
public abstract class EnemyFire : MonoBehaviour
{
    [SerializeField]
    protected GameObject bulletPrefab;

    //this is offset from the center of the ship that the bullet should appear in game.
    [SerializeField]
    protected float spawnOffsetScale = 0.2f;

    //this is serialized so the speed of bullets can be quickly adjusted in the editor.
    [SerializeField]
    protected float bulletSpeed = 1.5f;

    protected virtual void Start(){
        bulletPrefab.GetComponent<BulletMovement>().speed = bulletSpeed;
    }

    //each firing type has to define how it fires.
    public abstract void Fire();
}
