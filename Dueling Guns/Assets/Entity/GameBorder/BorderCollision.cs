using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c){
        print("wall collision called");
        Destroy(c.gameObject);
    }
}
