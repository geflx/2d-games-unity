using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
  
    public float delayTime;
    public int speed;

    void Update()
    {
       delayTime -= Time.deltaTime;
       
       if(delayTime <= 0.0f){
           transform.Translate(Vector2.left * speed * Time.deltaTime);
       } 
    }
}
