using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteafter1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyMe", 1);
    }
    void destroyMe()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
