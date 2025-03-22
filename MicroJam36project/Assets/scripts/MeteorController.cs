using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    float speed;
    void Start()
    {
        Invoke("Die", 10);
        speed = 0.33f;
    }
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - speed, gameObject.transform.position.y);
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
