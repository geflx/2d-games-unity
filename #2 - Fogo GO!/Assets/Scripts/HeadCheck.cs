using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCheck : MonoBehaviour
{

    GameObject Lumberjack;
    void Start(){
        Lumberjack = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision){

        Debug.Log("A!!");
        if(collision.collider.tag == "Player"){
            Debug.Log("B!!");
            Destroy(Lumberjack);
        }
    }
  
}
