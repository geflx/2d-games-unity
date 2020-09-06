using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    public float targetProgress;
    public float fillSpeed;

    private GameObject ground;
    private float groundWidth;

    private GameObject player;
    private float playerIniPos;
    private float playerCurrPos;
    private float totalWidth;

    private float playerOldPos;

    void Start(){
        ground = GameObject.Find("Ground");
        groundWidth = ground.GetComponent<SpriteRenderer>().sprite.rect.width;
        Debug.Log(groundWidth);

        player = GameObject.Find("Player");
        playerIniPos = player.transform.position.x;

        totalWidth = groundWidth - playerIniPos;
        Debug.Log("totalwidth: " + totalWidth);
        Debug.Log("playerIniPos: " + playerIniPos);

        slider = gameObject.GetComponent<Slider>();

        playerOldPos = playerIniPos;
    }

    void Update(){

        playerCurrPos = player.transform.position.x;
        Debug.Log("playerCurrPos: " + ( playerCurrPos - playerIniPos ));
        
        float increment;
        if(playerCurrPos != playerOldPos){
            playerOldPos = playerCurrPos;
            increment = ( playerCurrPos - playerIniPos ) * 100/ totalWidth;
            IncrementProgress(increment);
        }


    }
    public void IncrementProgress(float newIncrement){
        if(slider.value < targetProgress){
            slider.value += fillSpeed * newIncrement;
        }
    }

}
