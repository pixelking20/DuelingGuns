using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Player1Score;

    public int Player2Score;

    public void ScoreIncrement(int x,int i){
        if (x == 0)
            Player1Score += i;
        else
            Player2Score += i;
        UIUpdate();
    }

   private void UIUpdate(){

   } 
   
}
