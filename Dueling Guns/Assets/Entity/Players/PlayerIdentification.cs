using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class exists because both the playerSpawner and bulletCollider both use the playerID. It's seperated so that the field doesn't need to be changed in two different places.
public class PlayerIdentification : MonoBehaviour
{
    [SerializeField]
    public int playerID;
}
