using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn=4f;
    public float decreaseTime=0.3f;
    public float minStartTime=1f;

    public int spawnCounter = 0;
    public int lastKamaboko = -1;

    public int minIndexKamaboko;
    public int maxIndexKamaboko;

    public int minIndexShuriken;
    public int maxIndexShuriken;
    
    private void Update(){
        if(timeBtwSpawn <= 0){

            int rand = Random.Range(0, obstaclePatterns.Length);

            if(minIndexKamaboko <= rand && rand <=maxIndexKamaboko){
                if(lastKamaboko != -1){
                    if( (spawnCounter - lastKamaboko) < 10 ){
                        while(minIndexKamaboko <= rand && rand <=maxIndexKamaboko){
                            rand = Random.Range(0, obstaclePatterns.Length);
                        }
                    }else{
                        lastKamaboko = spawnCounter;
                    }
                }else{
                    lastKamaboko = spawnCounter;
                }
            }

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
