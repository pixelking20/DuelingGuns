using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this extends Single Fire since Burst Fire is just A modified Single Fire.
public class EnemyBurstFire : EnemySingleFire
{
    [SerializeField]
    protected float burstOffset = 0.1f;

    [SerializeField]
    protected int burstCount = 3;

    public override void Fire(){
        //starts a coroutine for the BurstFire. The reason it's a Coroutine is so it can use wait for seconds with the burstOffset.
        StartCoroutine(BurstFire());
    }

    private IEnumerator BurstFire(){
        for (int i = 0; i<burstCount; i++){
            //uses base.fire since the burst fire is just multiple single fires that just have a time offset
            base.Fire();
            yield return new WaitForSeconds(burstOffset);
        }
    }
    
}
