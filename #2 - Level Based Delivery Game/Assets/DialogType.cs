using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogType : MonoBehaviour
{

    public float startCountdown = 2.2f;
    public bool finished;

    public GameObject DialogManager;
    public GameObject DialogCanvas;

    public GameObject indicators;
    public GameObject buttons;

    void Start(){
        // ..
        finished = false;
    }

    void Update(){

        if(startCountdown > 0.0f){
            startCountdown -= Time.deltaTime;
        }else{
            if(!finished){
                DialogManager.SetActive(true);
                DialogCanvas.SetActive(true);
                indicators.SetActive(true);
                buttons.SetActive(true);

                finished = true;
            }
        }
    }
}
