using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItself : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 startPos;
    void Start()
    {
       Destroy (gameObject, 1);
    }
}
