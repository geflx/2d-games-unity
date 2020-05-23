using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //important

public class Health : MonoBehaviour
{

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update(){

        //health doesnt overcome 3 sprites
        if(health > numOfHearts){
            health = numOfHearts;
        }

        for(int i=0; i< hearts.Length; i++){

            if(i < health){
                hearts[i].sprite = fullHeart;
            }else{
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts){
                hearts[i].enabled = true;
            }else{
                hearts[i].enabled = false;
            }
        }
    }

}
