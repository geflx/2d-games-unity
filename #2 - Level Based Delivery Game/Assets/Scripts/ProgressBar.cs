using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private float targetProgress = 0;
    public float fillSpeed;


    void Start(){
        slider = gameObject.GetComponent<Slider>();
        IncrementProgress(0.75f);
    }

    void Update(){
        if(slider.value < targetProgress){
            slider.value += fillSpeed * Time.deltaTime;
        }
    }
    public void IncrementProgress(float newProgress){
        targetProgress = slider.value + newProgress;
    }

}
