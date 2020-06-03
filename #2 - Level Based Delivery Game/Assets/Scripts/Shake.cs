using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float waitTime;
    public float shakeTime;
    public float shakeIntensity;

    private float shaking;
    private float waiting;
    private int cyclesCounter;
    private int cycles = 5;
    private bool left;
    private int unbalanced = 0;

    void Start()
    {
        waiting = 0;
        left = true;
        cyclesCounter = cycles;
        shaking = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(waiting > 0){
            if(unbalanced == -1){
                transform.Rotate (0f, 0f, shakeIntensity );
                unbalanced = 0;
            }else if(unbalanced == 1){
                transform.Rotate (0f, 0f, (-1) * shakeIntensity );
                unbalanced = 0;
            }

            waiting -= Time.deltaTime;
            shaking = shakeTime;
        }else{
            if(shaking > 0){
                shaking -= Time.deltaTime;
                if(cyclesCounter > 3){
                    cyclesCounter--;
                }else{
                    cyclesCounter = cycles;

                    if(left){     

                        if(unbalanced == 1){
                            unbalanced = 0;
                        }else{
                            unbalanced = -1;
                        }
                        transform.Rotate (0f, 0f,  (-1) * shakeIntensity );

                        left = false;
                    }else{
                        if(unbalanced == -1){
                            unbalanced = 0;
                        }else{
                            unbalanced = 1;
                        }
                        transform.Rotate (0f, 0f,  shakeIntensity );
                        left = true;
                    }
                }

            }else{
                waiting = waitTime;
            }
        }
    }
}
