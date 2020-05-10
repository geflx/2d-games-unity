using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    GameObject Player;

    void Start(){
        Player = gameObject.transform.parent.gameObject;

    }

    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Toquei!");
        if(collision.collider.tag == "Ground"){

            Player.GetComponent<Player>().grounded = true;

        }else if(collision.collider.tag == "Fire"){
            

            Player.GetComponent<Player>().grounded = true;
            Player.GetComponent<Player>().health -=1;

        }
    }
    private void OnCollisionExit2D(Collision2D collision){
        if(collision.collider.tag == "Ground"){

            Player.GetComponent<Player>().grounded = false;

        }
    }
    
}
