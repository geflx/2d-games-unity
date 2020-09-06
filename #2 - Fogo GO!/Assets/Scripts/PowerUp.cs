using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private BoxCollider2D bc;
    
    public GameObject Player;
    
  //  public Animator animator;

    public bool touched = false; //Avoid powering up player again on collision

    void Start(){
        Player = GameObject.Find("Player");
    }

     void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            Destroy(gameObject);

            if(!touched){
                    Player.GetComponent<Player>().power +=1;
            }
            touched = true;
        }
    }
}
