using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : MonoBehaviour
{

    public GameObject Player;
    public float playerDistance;
    public float moveSpeed;

    public float delayToCheck;
    private float waitingDelay;
    private int direction;

    public bool run = false;
    
    void Start(){
        direction = -1;
        waitingDelay = delayToCheck;
        Player =  GameObject.Find("Player");
    }

    void Update(){
        playerDistance = Mathf.Abs(Player.transform.position.x - gameObject.transform.position.x);

        if(playerDistance <= 11.5f){
            run = true;
        }
        
        //if(Player.transform.position.x - gameObject.transform.position.x  > 20 )
            //Destroy(gameObject);
        


        if(waitingDelay > 0){
            waitingDelay -= Time.deltaTime;
        }else{
            if((Player.transform.position.x - gameObject.transform.position.x) < 0)
                direction = -1;
            else
                direction = 1;

            waitingDelay = delayToCheck;
        }
        

        Move(direction);
    }

    void Move(int direction){
        if(direction == -1){
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }else{
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }
}
