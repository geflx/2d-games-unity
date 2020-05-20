using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

   [Header("Player Info.")]
    public float moveSpeed;
    
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


    //public Text healthDisplay;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){

        //healthDisplay.text = "HP: " + health.ToString();

    
        animator.SetBool("doubleJump", false);

        if(grounded){
            animator.SetBool("isGrounded", true);
            extraJumps = extraJumpsValue;
        }else{
            animator.SetBool("isGrounded", false);
        }

        if(Input.GetKeyDown("space") && extraJumps>0){
                
                animator.SetBool("doubleJump", true);

                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;

        }else if(Input.GetKeyDown("space") && extraJumps==0 && grounded){

                rb.velocity = Vector2.up * jumpForce;            
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
    }
    void FixedUpdate(){
        moveHorizontal();   
    }

    void moveHorizontal(){
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

    }

}
