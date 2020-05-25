using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyes : MonoBehaviour
{
  
    public float distanceLimit;
    public float delayTime;
    public float speed;
    private float initialPos;

    void Start(){  
        initialPos = transform.position.x;
        distanceLimit = transform.position.x - distanceLimit;
    }
    void Update(){
        
        if(transform.position.x > distanceLimit){
           transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        delayTime -= Time.deltaTime;
        if(delayTime <= 0.0f){
            Destroy(gameObject);
        }
    }
}
