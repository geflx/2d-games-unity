using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralex : MonoBehaviour
{
    private float length;
    Vector2 startPos;
    public float scrollSpeed; //select in editor
    void Start()
    {
        startPos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
       float newPos = Mathf.Repeat( Time.time * scrollSpeed, length);
       transform.position = startPos + Vector2.right * newPos;
    }
}
