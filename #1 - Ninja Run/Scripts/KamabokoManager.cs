using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KamabokoManager : MonoBehaviour
{
    public Text kamabokoDisplay;
    
    public bool keepCounting = true;

    public GameObject Player;

    void Start(){
        Player = GameObject.Find("Player");
    }

    void Update(){
        if(keepCounting && Player.activeSelf){
            kamabokoDisplay.text = (Player.GetComponent<Player>().kamaboko).ToString();
        }
    }
}
