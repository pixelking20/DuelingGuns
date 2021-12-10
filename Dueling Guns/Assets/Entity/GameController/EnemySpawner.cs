using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //the position of the Empty Gameobject EnemySpawner. It's used as a base for the random spawns of the enemy
    private Transform spawnTransform; 


    [SerializeField] //the ScriptableObject that holds the number of each enemy during each wave.
    public Wave totalWave;
    
    //The number of seconds that each wave should last. The default value is 30 seconds.
    public int waveTime = 30;

    //The max offset from the position of the enemySpawner game object.
    public float maxSpawnOffset;

    //array of all enemy gameobjects
    public GameObject[] enemyprefabarray;

    void Start()
    {
        //gets the position of EnemySpawner at the start of the scene
        spawnTransform = GameObject.FindGameObjectWithTag("EnemySpawner").transform;

        //the control loop is contained in an coroutine so it can use the WaitForSeconds method
        StartCoroutine(SpawnerControlLoop());
    }

    //main coroutine that controls the spawning of all enemies.
    private IEnumerator SpawnerControlLoop(){
        //loops through the length of the waveList
        for (int i = 0; i<totalWave.waveList.Length; i++){
            //For each enemy type, It starts the spawnStage routine with how many ships should be in that stage and gives the prefab to the routine
            for (int x = 0; x<enemyprefabarray.Length; x++){
                StartCoroutine(SpawnStage(totalWave.waveList[i].waveArray[x], enemyprefabarray[i]));
            }
            //waits until that wave is over to start the next wave
            yield return new WaitForSeconds(waveTime);
        }
    }

    private IEnumerator SpawnStage(int x, GameObject enemyPrefab){
        float timeSegment = waveTime/x;
        for(int i = 0; i<x; i++){
            //sets a new random time to wait before spawning a ship.
            float waitTime = Random.Range(0,timeSegment);

            //waits for the random segment
            yield return new WaitForSeconds(waitTime);

            //determines a new random spawn that is clamped by the max offsets
            Vector3 randomspawn = spawnTransform.position + new Vector3(Random.Range(-maxSpawnOffset, maxSpawnOffset), 0,0);

            //sets a fifty/fifty if the ship spawns on the top or bottom of the screen
            if (Random.Range(0, 1f) > 0.5f){
            Instantiate(enemyPrefab, randomspawn, spawnTransform.rotation);
            }
            else{
            Instantiate(enemyPrefab, -1*randomspawn, Quaternion.Inverse(spawnTransform.rotation));
            }

            //waits the rest of timesegment
            yield return new WaitForSeconds(timeSegment - waitTime);
        }
    }
}
