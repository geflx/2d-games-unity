using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : MonoBehaviour{

    
    private BoxCollider2D bc;
    bool onFire;
   
    public Animator animator;

    void Start(){
        
        animator.SetBool("onFire", true);
        onFire = true;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && onFire){

            animator.SetBool("onFire", false);
            onFire = false;
            other.GetComponent<Player>().health -=1;
        }
    }
    
}
