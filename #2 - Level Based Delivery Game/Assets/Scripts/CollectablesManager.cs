using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesManager : MonoBehaviour
{
    public Text displayCollectables;
    
    void Start()
    {
        displayCollectables.text = PlayerPrefs.GetInt("Collectables").ToString();
    }

    void Update()
    {
        //displayCollectables.text = PlayerPrefs.GetInt("Collectables").ToString();
    }
}
