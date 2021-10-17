using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuiter : MonoBehaviour
{
    void Update()
    {
        //this script just allows the game to be quit at anypoint by hitting the escape key
        if (Input.GetKey("escape"))
			Application.Quit();
    }
}
