using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource[] sources;

    public bool thriller;
    public bool gameplay;

    // Start is called before the first frame update
    void Start()
    {
        thriller = false;
        gameplay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(thriller){

            sources[1].Pause();
            sources[0].Play();
            gameplay = false;
            thriller = false;

        }else if(gameplay){

            Debug.Log("PLAYED GAMEPLAY!");
            sources[0].Pause();
            sources[1].Play();
            thriller = false;
            gameplay = false;
        }
    }
}
