using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float moveSize, moveSpeed;

    private float movingValue;
    private Rigidbody2D rigidBody;

    [Header("Move Info.")]
    public float movingX, movingY;

    void Awake(){
        movingX = movingY = 0.0f;
        movingValue = 0.0f;
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update(){
        move();   
    }

    void move(){
               
        movingX = Input.GetAxis("Horizontal");
        movingY = Input.GetAxis("Vertical");

        //rigidBody.velocity = new Vector2(movingX * moveSpeed, rigidBody.velocity.x);
       // rigidBody.velocity = new Vector2(movingY * moveSpeed, rigidBody.velocity.y);
        rigidBody.velocity = new Vector2(movingX * moveSpeed, movingY * moveSpeed);
    
    }
  
}
