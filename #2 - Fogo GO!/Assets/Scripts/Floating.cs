using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float maxHeight;
    public float floatSpeed;

    private bool up;
    private float iniPosY;

    void Start(){
        up = true;
        iniPosY = transform.position.y;
    }

    void Update(){
        
        if(up){
            if((transform.position.y - iniPosY) < maxHeight){
                transform.Translate(Vector2.up * floatSpeed * Time.deltaTime);
            }else{
                up = false;
            }
        }else{
            if((transform.position.y - iniPosY) > 0.0){
                transform.Translate(Vector2.down * floatSpeed * Time.deltaTime);
            }else{
                up = true;
            }
        }
    }
}
