using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{

    private float length;
    private float startPos;
    public GameObject Cam;
    public float ParalaxEffect;
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void FixedUpdate()
    {
        float temp = (Cam.transform.position.x * (1 - ParalaxEffect));
        float dist = (Cam.transform.position.x * ParalaxEffect);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length) 
        { 
            startPos += length;
        } 
        else if(temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
