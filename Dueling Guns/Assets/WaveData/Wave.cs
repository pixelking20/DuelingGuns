using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script defines the scriptable Object Waveinfo
[CreateAssetMenu(fileName = "WaveInfo", menuName = "ScriptableObjects/WaveInfo", order = 1)]

//it defines a 2d array of ints. It starts at 10 but can be edited in the unity editor.
[System.Serializable]
public class Wave : ScriptableObject
{
    [SerializeField]
    public EnemyWave[] waveList = new EnemyWave[10];

    [System.Serializable]
public struct EnemyWave{
    public int[] waveArray;

}
}


