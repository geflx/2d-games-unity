using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;

    public float typingSpeed, firstCountdown = 2.0f;
    public GameObject continueButton, soundManager, indicatorManager, dialogImages, ThisDialog;

    public bool runningDialog;

    void Start(){
        StartCoroutine(Type());

        runningDialog = true;
        soundManager.GetComponent<Sound>().thriller = true;
    }

    void Update(){
        Debug.Log("Index is: " + index + ", sentences length: " + sentences.Length + " Sentences[1] is: " + sentences[1]);
        if(textDisplay.text == sentences[index] && !continueButton.activeSelf){
            continueButton.SetActive(true);
        }

        // Indicators On/Off.
        if(runningDialog)
            indicatorManager.GetComponent<Indicator>().active = false;
        else
            indicatorManager.GetComponent<Indicator>().active = true;
        
        // Stop playing thriller music and start gameplay.
        if(textDisplay.text == "" && index == sentences.Length-1 && runningDialog){
            soundManager.GetComponent<Sound>().gameplay = true;
            dialogImages.SetActive(false);

            runningDialog = false;
            index = 0;
            ThisDialog.SetActive(false);
        }
    }

    IEnumerator Type(){
        foreach(char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence(){
        
        Debug.Log("click");
        continueButton.SetActive(false);

        textDisplay.text = ""; // Clear display.
        
        if(index < sentences.Length-1 && runningDialog){
            index++;
            StartCoroutine(Type());
        }
    }
}
