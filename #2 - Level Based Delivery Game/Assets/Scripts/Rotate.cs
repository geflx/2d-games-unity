using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float maxHeight;
    public float floatSpeed;

    private Vector3 startPos;

    public AudioSource sound;
    public Collider2D myCollider;
    public SpriteRenderer mySprite, myShadow;

    private bool active;
    private float timer;

    void Start(){

        sound.enabled = false;
        myCollider.enabled = true;
        mySprite.enabled = true;
        myShadow.enabled = true;

        active = true;
        timer = 0.0f;

        startPos = transform.position;
    }
  
    private void Update(){

        if(!active){
            if(timer < 0.1f){
                timer = 3.0f;
            }else if(timer < 0.5f){
                Destroy(gameObject); // * Destroy Coin after 2.5s 
            }else{
                timer -= Time.deltaTime;
            }
        }

        if(active){
            transform.Rotate(0f, floatSpeed,  0f );
        }
    }

    void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("Player")){

            other.GetComponent<Player>().coins++;
            
            sound.enabled = true;
            myCollider.enabled = false;
            myShadow.enabled = false;
            mySprite.enabled = false;

            active = false;
        }
    }
}
