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

        if(collision.collider.tag == "Ground"){

            Player.GetComponent<Player>().grounded = true;

        }else if(collision.collider.tag == "Spring"){

            Debug.Log("yeah... spring!");
            Player.GetComponent<Player>().springJump = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision){
        if(collision.collider.tag == "Ground"){

            Player.GetComponent<Player>().grounded = false;

        }
    }
    
}
