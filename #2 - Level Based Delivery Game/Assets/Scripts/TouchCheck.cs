using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCheck : MonoBehaviour
{

    GameObject Player;
    GameObject Lumberjack;

    public bool touched = false; //Avoid damaging player again on collision

    void Start(){
        Player =  GameObject.Find("Player");
        Lumberjack = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.collider.tag == "Player"){
            if(!touched){
                Player.GetComponent<Health>().health -=1;
                Destroy(Lumberjack);
            }
            touched = true;
        }
    }
}
