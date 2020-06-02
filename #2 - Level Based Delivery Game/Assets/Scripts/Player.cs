using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

   [Header("Player Info.")]
    public float moveSpeed;
    public int power;
    
    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;
    

    [Header("Jump Info.")]
    public bool grounded = false;
    public float jumpForce = 5;
    public float extraJumpsValue = 1;
    public float extraJumps;

    [Header("Move Info.")]
    private float moveInput;

    public Joystick joystick;
    public bool pcMode;

    void Start(){
        power = PlayerPrefs.GetInt("Collectables");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
    
        animator.SetBool("doubleJump", false);

        if(grounded){
            animator.SetBool("isGrounded", true);
            extraJumps = extraJumpsValue;
        }else{
            animator.SetBool("isGrounded", false);
        }


        //Animation
        animator.SetFloat("speed", rb.velocity.x * rb.velocity.x);
        if(rb.velocity.y > 0){
            animator.SetBool("goingUp", true);
        }else{
            animator.SetBool("goingUp", false);
        }

        if(rb.velocity.x >=0){
            animator.SetBool("goingRight", true);
        }else{
            animator.SetBool("goingRight", false);
        }
        jump();
    }
    void FixedUpdate(){
        moveHorizontal();   
    }

    void moveHorizontal(){
        if(pcMode){
            moveInput = Input.GetAxis("Horizontal");
        }else{ 
            if(joystick.Horizontal >= .2f){ // Controller sensitivity
                moveInput = 1f; 
            }else if(joystick.Horizontal <= -.2f){
                moveInput = -1f;
            }else{
                moveInput = 0f;
            }
        }
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

    }

    void jump(){
        if(pcMode){
            if(Input.GetKeyDown("space") && extraJumps>0){

                    animator.SetBool("doubleJump", true);

                    rb.velocity = Vector2.up * jumpForce;
                    extraJumps--;

            }else if(Input.GetKeyDown("space") && extraJumps==0 && grounded){
                    rb.velocity = Vector2.up * jumpForce;            
            }  
        }else{
            float verticalMove = joystick.Vertical;

            if(verticalMove >=.5f && extraJumps>0){
                    animator.SetBool("doubleJump", true);

                    rb.velocity = Vector2.up * jumpForce;
                    extraJumps--;

            }else if(verticalMove >=.5f && extraJumps==0 && grounded){
                    rb.velocity = Vector2.up * jumpForce;            
            }  
        }
    }
}
