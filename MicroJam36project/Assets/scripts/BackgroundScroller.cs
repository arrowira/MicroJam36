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
        B1.transform.position = new Vector3(B1.transform.position.x - speed, B1.transform.position.y, 100);
        B2.transform.position = new Vector3(B2.transform.position.x - speed, B2.transform.position.y, 100);
        B3.transform.position = new Vector3(B2.transform.position.x - speed, B2.transform.position.y, 100);
        if (B1.transform.position.x <= -15)
        {
            B1.transform.position = new Vector3(15, B1.transform.position.y, 100);
        }
        if (B2.transform.position.x <= -15)
        {
            B2.transform.position = new Vector3(15, B2.transform.position.y, 100);
        }
        if (B3.transform.position.x <= -15)
        {
            B3.transform.position = new Vector3(15, B3.transform.position.y, 100);
        }
    }
}
