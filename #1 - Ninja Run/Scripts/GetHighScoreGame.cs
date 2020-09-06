using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighScoreGame : MonoBehaviour
{
    public Text highScore;
    public GameObject ScoreManager;

    // Update is called once per frame
    void Update()
    {
        int currScore = ScoreManager.GetComponent<ScoreManager>().score;
        
        if(currScore > PlayerPrefs.GetInt("HighScore")){
            highScore.text = currScore.ToString();
        }else{
            highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }
}
