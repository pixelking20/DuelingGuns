using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Player1Score;

    public int Player2Score;

    //this method is called by bulletCollision when it collides with an object.
    public void ScoreIncrement(int x,int i){
        if (x == 0)
            Player1Score += i;
        else
            Player2Score += i;
        //calls UIUpdate after the score has been modified. It's called here so the UI doesn't have to update everyframe.
        UIUpdate();
    }

   private void UIUpdate(){

   } 
   
}
