using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : MonoBehaviour{

    
    private BoxCollider2D bc;
    public bool onFire;
    
    public GameObject bonfire;
    public GameObject Player;
  //  public Animator animator;

    public bool touched = false; //Avoid burning player again on collision

    void Start(){
        
       // animator.SetBool("onFire", true);
        Player = GameObject.Find("Player");
        onFire = true;

    }

    void Update(){
        if(!onFire){
           // animator.SetBool("onFire", false);
        }

    }

     void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            Destroy(gameObject);
            Debug.Log("Burn Player, burn!");
            if(!touched){
                Player.GetComponent<Health>().health -=1;
            }else{
                Debug.Log("Tried to burn player again, but DENIED!");
            }
            touched = true;
        }
    }
}
