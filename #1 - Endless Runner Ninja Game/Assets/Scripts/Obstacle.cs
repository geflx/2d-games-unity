using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speedLeftLimit;
    public float speedRightLimit;
    private float mySpeed;

    private float crazyKnife;
    public float crazyKnifePercentage; //set this in Editor
    Vector2 startPos;

    private void Start(){
        crazyKnife = Random.Range(0,100);
        if(crazyKnife <= (crazyKnifePercentage)){
            mySpeed = 20;
        }else{
            mySpeed = Random.Range(speedRightLimit, speedRightLimit);
        }
        startPos = transform.position;

        
    }
    private void Update(){
        transform.Translate(Vector2.left * mySpeed * Time.deltaTime);

        if( (transform.position.x - startPos.x)*(transform.position.x - startPos.x) >=60){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Bati!");
        Destroy(gameObject); // Destroy on contact
        if(other.CompareTag("Player")){
            Debug.Log("Player!!");
            other.GetComponent<Player>().health -= damage;
        }else{
            Debug.Log("Outra coisa!");
        }
    }
}
