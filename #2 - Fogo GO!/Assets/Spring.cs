using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
	public Animator anim;
	public GameObject player;

	void OnTriggerEnter2D (Collider2D other){
         if(other.name == "Player")
         {
         	player.GetComponent<Player>().springJump = true;
        	anim.SetBool("PlayAnim", true);
    	}
    }

    void FixedUpdate(){
        	anim.SetBool("PlayAnim", false);
    }

}
