using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Attack : MonoBehaviour
{
   public int damage;

    public float delayTime;
    public int speed;

    Vector2 startPos;

    private void Start(){
        startPos = transform.position;
    }
    void Update()
    {
       delayTime -= Time.deltaTime;
       
       if(delayTime <= 0.0f){
           transform.Translate(Vector2.left * speed * Time.deltaTime);
       }

       if( (transform.position.x - startPos.x)*(transform.position.x - startPos.x) >=100){
            Destroy(gameObject); // ! Destroying Obstacle after a considerate distance from Player;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Destroy(gameObject); // * Destroy Obstacle when touch Player;
            other.GetComponent<Health>().health -= damage;
        }
    }
}
