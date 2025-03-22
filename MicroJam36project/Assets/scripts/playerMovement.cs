using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float upDownSpeed;
    [SerializeField]
    private Rigidbody2D rb;

    int Health = 100, Fuel = 100, Score = 0, Money = 0;

    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("hi");
            rb.AddForce(Vector2.up * upDownSpeed);
        }
        if(Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.up * -upDownSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Health -= 10;
            collision.gameObject.GetComponent<MeteorController>().Die();
        }
        if (collision.gameObject.tag == "Fuel")
        {
            Fuel += 10;
            collision.gameObject.GetComponent<MeteorController>().Die();
        }
        if (collision.gameObject.tag == "Normal")
        {
            Money += 10;
            collision.gameObject.GetComponent<MeteorController>().Die();
        }
    }
}
