using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public bool active;
    public GameObject indicatorList;
    public GameObject buttonList;

    void Start(){
        active = false;
        indicatorList.SetActive(false);
        buttonList.SetActive(false);
    }

    void Update(){
        HandleIndicators();
    }

    void HandleIndicators(){
        if(active){
            indicatorList.SetActive(true);
            buttonList.SetActive(true);
        }else{
            indicatorList.SetActive(false);
            buttonList.SetActive(false);
        }
    }

}
