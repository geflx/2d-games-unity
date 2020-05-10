using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCheck : MonoBehaviour
{
    GameObject Player;


    void Start(){
        Player = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("bati no trigger");
        if(collision.collider.tag == "Fire"){
            Player.GetComponent<Player>().health--;
        }
    }
    private void OnCollisionExit2D(Collision2D collision){
        //Delete bonfire: code!
        //Change bonfire animation?
        
    }
    
}
