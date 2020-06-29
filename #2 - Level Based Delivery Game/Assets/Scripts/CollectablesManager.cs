using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectablesManager : MonoBehaviour
{
    public TextMeshProUGUI displayCollectables;
    
    void Start()
    {
        displayCollectables.text = PlayerPrefs.GetInt("Collectables").ToString();
    }

    void Update()
    {
        //displayCollectables.text = PlayerPrefs.GetInt("Collectables").ToString();
    }
}
