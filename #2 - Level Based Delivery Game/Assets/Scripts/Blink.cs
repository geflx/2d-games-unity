using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public bool blink;
    public float duration;
    public float blinkWait;

    public Image lockImg;

    private float runningTime;
    private float waitingToBlink;
    private bool spriteIsOn;

    void Start(){
        blink = false;
        lockImg.enabled = false;
        spriteIsOn = false;
    }

    void Update(){

        
        if(blink){
            spriteIsOn = true;
            lockImg.enabled = true;

            runningTime = duration;
            waitingToBlink = blinkWait;   

            blink = false;
        }

        if(runningTime >= 0.0f){
            runningTime -= Time.deltaTime;
            waitingToBlink -= Time.deltaTime;
        }else{
            spriteIsOn = false;
            lockImg.enabled = false;
        }

        if(waitingToBlink <= 0.0f){

            spriteIsOn = !spriteIsOn;

            if(spriteIsOn){ // Set sprite On
                lockImg.enabled = true;
            }else{  // Set sprite Off
                lockImg.enabled = false;
            }

            waitingToBlink = blinkWait;
        }
        
        

    }
}
