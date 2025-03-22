using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    float speed;
    void Start()
    {
        Invoke("Die", 10);
        speed = 0.15f;
    }
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - speed, gameObject.transform.position.y);
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "player")
        {
            Die();
        }
    }
}
