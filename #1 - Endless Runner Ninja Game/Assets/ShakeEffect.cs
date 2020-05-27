using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    public float waitTime;
    public float shakeTime;
    public float shakeIntensity;

    private float shaking;
    private float waiting;
    private int cyclesCounter;
    private int cycles = 5;
    private bool left;

    void Start()
    {
        left = true;
        cyclesCounter = cycles;
        shaking = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(waiting > 0){
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
                        transform.Rotate (0f, 0f,  (-1) * shakeIntensity );
                        left = false;
                    }else{
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
