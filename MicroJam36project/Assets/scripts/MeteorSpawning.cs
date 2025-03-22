using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawning : MonoBehaviour
{
    public GameObject MeteorPrefab;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if(Random.Range(1, 30) == 1)
        {
            GameObject M = Instantiate(MeteorPrefab, new Vector3(10 + Random.Range(1, 10), -5 + Random.Range(1, 10), 1), Quaternion.identity);
            float scale = Random.Range(0.5f, 3f);
            M.transform.localScale = new Vector3(scale, scale, 1);
        }
    }
}
