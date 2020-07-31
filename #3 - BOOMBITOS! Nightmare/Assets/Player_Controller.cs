using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float moveSize, moveSpeed;

    private float movingValue;
    private Rigidbody2D rigidBody;

    public GameObject bomb;

    [Header("Move Info.")]
    public float movingX, movingY;

    void Awake(){
        movingX = movingY = 0.0f;
        movingValue = 0.0f;
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update(){
        move();   
        throwBomb();
    }

    void move(){
               
        movingX = Input.GetAxis("Horizontal");
        movingY = Input.GetAxis("Vertical");

        //rigidBody.velocity = new Vector2(movingX * moveSpeed, movingY * moveSpeed);   
        transform.Translate(movingX * moveSpeed, movingY * moveSpeed, 0);

    }

    void throwBomb(){

        if(Input.GetKeyDown("space")) {

            float x, y, z;
            x = transform.position.x;
            y = transform.position.y;
            z = transform.position.z;

            Instantiate(bomb, new Vector3(x, y, z), Quaternion.identity);
        }
    }
  
}
