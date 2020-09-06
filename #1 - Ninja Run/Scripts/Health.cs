using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //important

public class Health : MonoBehaviour
{

    public int health;
    public int healthLimit;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private int lastHealth = 3;

    public AudioSource audio1, audio2, audio3;
 

    void Start(){
        
        AudioSource[] aSources = GetComponents<AudioSource>();
        audio1 = aSources[0];
        audio2 = aSources[1];
        audio3 = aSources[2];

    }
    void Update(){

        if(health > healthLimit){
            health = healthLimit;
        }

        if(lastHealth > health){

            Debug.Log("Play!");
            audio2.Play();

            lastHealth = health;

        }

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
