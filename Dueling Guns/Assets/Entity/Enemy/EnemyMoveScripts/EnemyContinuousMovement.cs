using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContinuousMovement : EnemyMove
{
    [SerializeField]
    private float fireWait = 2.0f;

    protected override IEnumerator MovementLoop(){
        StartCoroutine(continousFire());
        //a continuous loop that moves the ship at a constant speed.
        while(true){
            transform.position+= Time.deltaTime*transform.up*speedFactor;
            yield return new WaitForSeconds(0.05f);
        }
    }

    //a continous loop that calls Fire every fireWait seconds.
    private IEnumerator continousFire(){
        while(true){
            Fire();
            yield return new WaitForSeconds(fireWait);
        }
    }
}
