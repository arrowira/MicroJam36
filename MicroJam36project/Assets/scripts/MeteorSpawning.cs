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
    public int FuelChance, NormalChance, DamageChance;
    public float Difficulty = 1;
    void Start()
    {
        MArray = new GameObject[] { MeteorPrefab, EnemyPrefab, FuelPrefab };
        Difficulty = 1;
    }
    void FixedUpdate()
    {
        Difficulty += 0.0001f;
        if(Random.Range(1, 1437) == 1)
        {
            GameObject M = Instantiate(HealPrefab, new Vector3(40, -12 + Random.Range(1, 25), 1), Quaternion.identity);
            float scale = Random.Range(0.5f * scaleMod, 0.75f * scaleMod);
            M.transform.localScale = new Vector3(scale, scale, 1);
        }
        if(Random.Range(1, 70) == 1)
        {
            GameObject Pre = MeteorPrefab;
            int rand = Random.Range(1, 101);
            FuelChance = 25;
            DamageChance = 40;
            if(rand <= DamageChance)
            {
                Pre = EnemyPrefab;
            }
            if(rand<= DamageChance + FuelChance && rand > DamageChance)
            {
                Pre = FuelPrefab;
            }
            GameObject M = Instantiate(Pre, new Vector3(40, -12 + Random.Range(1, 25), 1), Quaternion.identity);
            float scale = Random.Range(0.5f*scaleMod, 1.75f*scaleMod);
            M.transform.localScale = new Vector3(scale, scale, 1);
        }
    }
}
