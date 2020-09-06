using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScrpit : MonoBehaviour
{
    private BoxCollider2D bc;
    
    public GameObject bonfire;
    public GameObject Player;
  //  public Animator animator;

    public bool touched = false; //Avoid powering up player again on collision

    void Start(){
        Player = GameObject.Find("Player");
    }

    void Update(){

    }
    
  
     void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            Destroy(gameObject);

            if(!touched){
                if(Player.GetComponent<Player>().power < 2){
                    Player.GetComponent<Player>().power +=1;
                }
            }
            touched = true;
        }
    }
}
