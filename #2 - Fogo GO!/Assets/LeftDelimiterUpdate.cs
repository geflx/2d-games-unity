using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDelimiterUpdate : MonoBehaviour
{
    public float lastBox;

    private GameObject player;

    void Start(){
        lastBox = transform.position.x;

        player = GameObject.Find("Player");
    }

    void Update(){
        if( (player.transform.position.x - lastBox) > 10){
            transform.position = new Vector2(lastBox, transform.position.y);
        }
    }
}
