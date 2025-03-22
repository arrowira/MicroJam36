using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawning : MonoBehaviour
{
    public GameObject MeteorPrefab;
    public GameObject EnemyPrefab;
    public GameObject FuelPrefab;

    public GameObject[] MArray = new GameObject[3];
    void Start()
    {
        MArray = new GameObject[] { MeteorPrefab, EnemyPrefab, FuelPrefab };
    }
    void FixedUpdate()
    {
        if(Random.Range(1, 30) == 1)
        {
            GameObject Pre = MeteorPrefab;
            int rand = Random.Range(1, 101);
            if(rand <= 10)
            {
                Pre = EnemyPrefab;
            }
            if(rand<= 40 && rand > 10)
            {
                Pre = FuelPrefab;
            }
            GameObject M = Instantiate(Pre, new Vector3(10 + Random.Range(1, 10), -5 + Random.Range(1, 10), 1), Quaternion.identity);
            float scale = Random.Range(0.5f, 3f);
            M.transform.localScale = new Vector3(scale, scale, 1);
        }
    }
}
