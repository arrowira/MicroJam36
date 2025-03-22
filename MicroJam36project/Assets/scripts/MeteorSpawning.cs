using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawning : MonoBehaviour
{
    public GameObject MeteorPrefab;
    public GameObject EnemyPrefab;
    public GameObject FuelPrefab;
    public GameObject HealPrefab;
    public float scaleMod = 1;

    public GameObject[] MArray = new GameObject[3];
    void Start()
    {
        MArray = new GameObject[] { MeteorPrefab, EnemyPrefab, FuelPrefab };
    }
    void FixedUpdate()
    {
        if(Random.Range(1, 250) == 1)
        {
            GameObject M = Instantiate(HealPrefab, new Vector3(10 + Random.Range(1, 10), -5 + Random.Range(1, 10), 1), Quaternion.identity);
            float scale = Random.Range(0.5f * scaleMod, 0.75f * scaleMod);
            M.transform.localScale = new Vector3(scale, scale, 1);
        }
        if(Random.Range(1, 87) == 1)
        {
            GameObject Pre = MeteorPrefab;
            int rand = Random.Range(1, 101);
            if(rand <= 25)
            {
                Pre = EnemyPrefab;
            }
            if(rand<= 50 && rand > 25)
            {
                Pre = FuelPrefab;
            }
            GameObject M = Instantiate(Pre, new Vector3(10 + Random.Range(1, 11), -5 + Random.Range(1, 10), 1), Quaternion.identity);
            float scale = Random.Range(0.5f*scaleMod, 1f*scaleMod);
            M.transform.localScale = new Vector3(scale, scale, 1);
        }
    }
}
