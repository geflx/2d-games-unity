using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage;
    public float speed;

    Vector2 startPos;

    private void Start(){
        startPos = transform.position;
    }
    private void Update(){
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if( (transform.position.x - startPos.x)*(transform.position.x - startPos.x) >=80){
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
