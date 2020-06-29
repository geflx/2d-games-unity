using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float maxHeight;
    public float floatSpeed;

    private bool goRight;
    private Vector3 startPos;

    public AudioSource sound;
    public Collider2D myCollider;
    public SpriteRenderer mySprite, myShadow;

    void Start(){

        sound.enabled = false;
        myCollider.enabled = true;
        mySprite.enabled = true;
        myShadow.enabled = true;

        goRight = true;
        startPos = transform.position;
        GameObject.Find("Sound");
    }
    
    private void Update(){
        transform.Rotate(0f, floatSpeed,  0f );
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){

            other.GetComponent<Player>().coins++;
            
            sound.enabled = true;
            myCollider.enabled = false;
            myShadow.enabled = false;
            mySprite.enabled = false;

            // TODO Destroy object after one second!
            //Destroy(gameObject); // * Destroy Obstacle when touch Player;
        }
    }
}
