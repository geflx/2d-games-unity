using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpScore : MonoBehaviour
{
    public TextMeshProUGUI powerDisplay;
    public GameObject Player;

    void Start(){
        Player = GameObject.Find("Player");
    }
    void Update(){
        int power = Player.GetComponent<Player>().power;
        powerDisplay.text = power.ToString();
        PlayerPrefs.SetInt("Collectables", power);
    }
    
}
