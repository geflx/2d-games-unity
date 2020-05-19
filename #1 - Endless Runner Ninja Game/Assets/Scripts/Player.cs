using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; //Android Inputs

using UnityEngine.SceneManagement; //Scoreboard
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player Characteristics")]
    public float health = 3;
    public float moveSpeed = 5f;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;

    [Header("Jump Utilities")]
    public bool grounded = false;
    public float jumpForce = 5;
    public float extraJumpsValue = 1;
    public float extraJumps;

    public Text healthDisplay;
    public GameObject gameOver;



    void Start(){

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update(){

        healthDisplay.text = "HP: " + health.ToString();

        if(health <= 0){ //Dead!!
           gameOver.SetActive(true);
           Destroy(gameObject);
           Destroy(GameObject.Find("Spawner").GetComponent<Spawner>());
          GameObject.Find("Score Manager").GetComponent<ScoreManager>().keepCounting = false;
        }

        if(grounded){
            extraJumps = extraJumpsValue;
        }
        if(CrossPlatformInputManager.GetButtonDown("Jump") && extraJumps>0){
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
        }else if(CrossPlatformInputManager.GetButtonDown("Jump") && extraJumps==0 && grounded){
                rb.velocity = Vector2.up * jumpForce;            
        }

        if(CrossPlatformInputManager.GetButtonDown("Down") && grounded==false){
            extraJumps=0;
            rb.velocity = Vector2.down * 2*jumpForce;
        }
        if(!grounded){
            animator.SetBool("onAir",true);
        }else{
            animator.SetBool("onAir",false);
        }
    }

    void moveCharacter(float horizontal){
        animator.SetFloat("speed", (rb.velocity.x * rb.velocity.x));
    }
   
}
