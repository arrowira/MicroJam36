using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundTile : MonoBehaviour
{
    float speed = 0.077f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x - speed, transform.position.y, 100);
        if(transform.position.x < -40)
        {
            transform.position = new Vector3(30, transform.position.y, 100);
        }
       
    }
}
