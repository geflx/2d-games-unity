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
    public float moveSpeed = 5f;
    public int kamaboko = 0;
    public int kamabokoLimit;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;

    [Header("Jump Utilities")]
    public bool grounded = false;
    public float jumpForce = 5;
    public float extraJumpsValue = 1;
    public float extraJumps;

    public GameObject gameOver;

    private int waitCycles = 30;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update(){

        if(kamaboko == kamabokoLimit){
            GetComponent<Health>().health ++;
            GetComponent<Health>().audio3.Play();

            kamaboko = 0;
        }

        if(GetComponent<Health>().health <= 0){ // Dead in Combat

           gameOver.SetActive(true);

           Destroy(GameObject.Find("Spawner").GetComponent<Spawner>());

           GameObject.Find("Score Manager").GetComponent<ScoreManager>().keepCounting = false;
           GameObject.Find("Kamaboko Manager").GetComponent<KamabokoManager>().keepCounting = false;
        
            if(waitCycles > 0)
                --waitCycles;
            else
                Destroy(gameObject);
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
            animator.SetBool("goDown",true);
            rb.velocity = Vector2.down * 2*jumpForce;
        }
        if(!grounded){
            animator.SetBool("onAir",true);
        }else{
            animator.SetBool("onAir",false);
            animator.SetBool("goDown",false);
        }
    }

    void moveCharacter(float horizontal){
        animator.SetFloat("speed", (rb.velocity.x * rb.velocity.x));
    }
   
}
