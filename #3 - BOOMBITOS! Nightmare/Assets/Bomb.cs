using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float countdown;

    void Update() {

        if(countdown >= 0.0f) {
            countdown -= Time.deltaTime;
        }
        else{
            Destroy(gameObject);
        }
        
    }
}
