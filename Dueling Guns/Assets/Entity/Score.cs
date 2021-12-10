using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is used to just store the value of each objects score. It's in it's own class so the bullet collision can easily grab the component and retrieve the score.
public class Score : MonoBehaviour
{
    public int objectScore;
}
