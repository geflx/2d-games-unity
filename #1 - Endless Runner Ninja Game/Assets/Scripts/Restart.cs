using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.CrossPlatformInput; //Android Inputs

using UnityEngine.SceneManagement; //Set Scene Management ON

public class Restart : MonoBehaviour
{
    void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("Restart")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
