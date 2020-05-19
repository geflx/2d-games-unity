using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreDisplay;

    public bool keepCounting = true;

    void Start(){
        score = 0;
    }
    private void Update(){
        if(keepCounting){
            scoreDisplay.text = "Score: " + score.ToString();
        }
    }
    void OnTriggerEnter2D(Collider2D other){        
        if(other.CompareTag("Obstacle") && keepCounting){
            score++;
        }
    }

}
