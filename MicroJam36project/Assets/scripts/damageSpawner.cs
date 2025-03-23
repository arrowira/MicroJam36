using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject system;
    public void spawnParticles()
    {
        Instantiate(system).transform.position = transform.position;
    }
}
