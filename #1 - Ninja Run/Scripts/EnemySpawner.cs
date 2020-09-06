using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
public GameObject[] obstaclePatterns;

    public float timeBtwSpawn;
    public float startTimeBtwSpawn=4f;
    public float decreaseTime=0.3f;
    public float minStartTime=1f;

    public int spawnCounter = 0;


    private void Update(){
        if(timeBtwSpawn <= 0){

            int rand = Random.Range(0, obstaclePatterns.Length);

            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;

            if(startTimeBtwSpawn > minStartTime){
                startTimeBtwSpawn -= decreaseTime;
            }

            spawnCounter++;

        }else{
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}

