using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : MonoBehaviour{

    
    private BoxCollider2D bc;
    public bool onFire;
    
    public GameObject bonfire;
    public GameObject Player;
  //  public Animator animator;

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
    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.collider.tag == "Player"){
            Destroy(gameObject);
            Debug.Log("Burned player!! ");
            Player.GetComponent<Health>().health -=1;
        }

      
    } 
    
}
