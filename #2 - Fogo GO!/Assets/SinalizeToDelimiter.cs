using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinalizeToDelimiter : MonoBehaviour
{

    public BoxCollider2D boxCol;

    private GameObject leftDelim;
    
    void Awake(){
        leftDelim = GameObject.Find("LeftDelimiter");
    }

    void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("Player")){

            
            if(leftDelim.GetComponent<LeftDelimiterUpdate>().lastBox < other.transform.position.x){
                leftDelim.GetComponent<LeftDelimiterUpdate>().lastBox = other.transform.position.x;
            }
        }
    }
}
