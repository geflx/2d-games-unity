using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpScore : MonoBehaviour
{
    public Text powerDisplay;
    public GameObject Player;

    void Start(){
        Player = GameObject.Find("Player");
    }
    void Update(){
        int power = Player.GetComponent<Player>().power;
        powerDisplay.text = power.ToString();
    }
    
}
