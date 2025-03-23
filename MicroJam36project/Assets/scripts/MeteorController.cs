using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    float speed;
    private Rigidbody2D rb;
    private float mod;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float randTurn = Random.Range(-3, 3);
        rb.AddTorque(10 * randTurn);
        Invoke("Die", 10);
        speed = 0.15f;
        mod = GameObject.Find("MeteorSpawner").GetComponent<MeteorSpawning>().Difficulty;
        if (mod < 3)
        {
            GameObject.Find("numberPanelManager").GetComponent<numberMan>().setDifficulty((int)((mod - 1) * 5));
        }
        
    }
    void FixedUpdate()
    {
        
        //Debug.Log("M: " + mod);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - (speed*mod), gameObject.transform.position.y);
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
