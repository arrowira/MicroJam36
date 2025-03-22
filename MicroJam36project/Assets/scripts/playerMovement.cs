using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour 
{

    public float upDownSpeed;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    numberMan npm;

    int Health = 100, Fuel = 100, Score = 0, Money = 0;

    void Start()
    {
        InvokeRepeating("Tick", 0.3f, 0.3f);
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * upDownSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.up * -upDownSpeed);
        }

        if (Health <= 0)
        {
            SceneManager.LoadScene("MainScene");
        }

        if (Fuel <= 0)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Health -= 10;
            collision.gameObject.GetComponent<MeteorController>().Die();
        }
        if (collision.gameObject.tag == "Fuel")
        {
            npm.enable();
            Fuel += 10;
            collision.gameObject.GetComponent<MeteorController>().Die();
        }
        if (collision.gameObject.tag == "Normal")
        {
            npm.enable();
            Money += 10;
            collision.gameObject.GetComponent<MeteorController>().Die();
        }
    }

    void Tick()
    {
        Fuel -= 1;
    }
    
}
