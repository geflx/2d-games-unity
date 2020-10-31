using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog2_Truck : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;

    public float typingSpeed, firstCountdown = 2.0f;
    public GameObject continueButton, soundManager, indicatorManager, dialogImages;

    public bool runningDialog;

    void Start(){
        StartCoroutine(Type());

        runningDialog = true;
        soundManager.GetComponent<Sound>().thriller = true;
    }

    void Update(){
        
        if(textDisplay.text == sentences[index] && !continueButton.activeSelf){
            continueButton.SetActive(true);
        }

        //Stop playing thriller music and start gameplay
        if(textDisplay.text == "" && index == sentences.Length-1 && runningDialog){
            Debug.Log("Ending dialog...");
            soundManager.GetComponent<Sound>().gameplay = true;
            indicatorManager.GetComponent<Indicator>().active = true;
            dialogImages.SetActive(false);

            //runningDialog = false;
            Destroy(gameObject);
            index = 0;
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
