using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    float speed = 0.077f;
    public GameObject B1;
    public GameObject B2;
    public GameObject B3;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        float mod = GameObject.Find("MeteorSpawner").GetComponent<MeteorSpawning>().Difficulty;
        B1.transform.position = new Vector3(B1.transform.position.x - (speed*mod), B1.transform.position.y, 100);
        B2.transform.position = new Vector3(B2.transform.position.x - (speed * mod), B2.transform.position.y, 100);
        B3.transform.position = new Vector3(B2.transform.position.x - (speed * mod), B2.transform.position.y, 100);
        if (B1.transform.position.x <= -20)
        {
            B1.transform.position = new Vector3(10, B1.transform.position.y, 100);
        }
        if (B2.transform.position.x <= -20)
        {
            B2.transform.position = new Vector3(10, B2.transform.position.y, 100);
        }
        if (B3.transform.position.x <= -20)
        {
            B3.transform.position = new Vector3(10, B3.transform.position.y, 100);
        }
    }
}
