using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
    private Image image;
    Color c;
    public bool goToGame;

     void Start() {
        image = GetComponent<Image>();
        c = image.color;
    }
    
    void Update(){
        
        if(goToGame){
            while( c.a < 1f){
                c.a += 0.01f;
                image.color = c;
            }
        }

    }
}
