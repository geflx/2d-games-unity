using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : MonoBehaviour
{

    public GameObject Player;
    public float playerDistance;
    public float moveSpeed;

    public bool run = false;
    
    void Start(){
        Player =  GameObject.Find("Player");
    }

    void Update(){
        playerDistance = Mathf.Abs(Player.transform.position.x - gameObject.transform.position.x);

        if(playerDistance <= 11.5f){
            run = true;
        }
        
        if(Player.transform.position.x - gameObject.transform.position.x  > 20 ){
            Destroy(gameObject);
        }
        Move();
    }

    void Move(){
        if(run){
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}
