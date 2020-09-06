using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinScore : MonoBehaviour
{
    public TextMeshProUGUI coinDisplay;
    public GameObject Player;

    void Start(){
        Player = GameObject.Find("Player");
    }
    void Update(){
        int coins = Player.GetComponent<Player>().coins;
        coinDisplay.text = coins.ToString();
    }
    
}
