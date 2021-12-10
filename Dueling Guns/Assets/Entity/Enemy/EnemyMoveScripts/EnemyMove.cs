using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is the abstract class that defines all types of movement. It's main goal of design was so different movement types could be drag and drop in the editor.
public abstract class EnemyMove : MonoBehaviour
{
    [SerializeField]
    protected float speedFactor = 1.0f;

    //movement has a reference to the firecontrol because movement controls when the ship fires.
    [SerializeField]
    protected EnemyFire fireControl;
    protected virtual void Start()
    {
        fireControl = gameObject.GetComponent<EnemyFire>();
        StartCoroutine(MovementLoop());
    }

    //this method is made to easily reference the fire mothod of the fireControl.
    protected virtual void Fire(){
        fireControl.Fire();
    }

    //each movement type needs to define how that movementtype should work
    protected abstract IEnumerator MovementLoop();
}
