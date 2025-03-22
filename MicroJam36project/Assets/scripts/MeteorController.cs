using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    float speed;
    void Start()
    {
        Invoke("Die", 10);
        speed = 0.5f;
    }
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - speed, gameObject.transform.position.y);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
