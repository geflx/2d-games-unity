using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckDialog : MonoBehaviour
{
    public float startCountdown;
    private bool runDialog;
    public GameObject DialogManager, DialogCanvas, indicators, buttons;
    public BoxCollider2D boxC;

    void Start(){
        runDialog = false;
    }

    void Update(){

        if(runDialog && startCountdown > 0.0f){
        	startCountdown -= Time.deltaTime;
        }else if(runDialog && startCountdown <= 0.0f){

            DialogManager.GetComponent<Dialog>().runningDialog = true;

            DialogManager.SetActive(true);
            DialogCanvas.SetActive(true);
            indicators.SetActive(false);
            buttons.SetActive(true);

        	runDialog = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player")
            runDialog = true;
    }
}
