using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour 
{

    public float upDownSpeed;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    numberMan npm;
    [SerializeField]
    private Image hpBar;
    [SerializeField]
    private Image powerBar;
    private int fuelCap = 100;
    float Health = 100, Fuel = 100, Score = 0, Money = 0;
    [SerializeField]
    private GameObject fuelDeathpanel;

    public int LastHit;

    void Start()
    {
        InvokeRepeating("Tick", 0.3f, 0.3f);
    }
    void FixedUpdate()
    {
        hpBar.fillAmount = Health / 100.0f;
        powerBar.fillAmount = Fuel / 100.0f;
        if(Fuel > fuelCap)
        {
            Fuel = fuelCap;
        }

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
            rb.AddForce(transform.right * -20, ForceMode2D.Force);
            Invoke("fuelDeath", 6);
            Invoke("fuelDeathMessage", 0);
        }
        LastHit += 1;
    }
    private void fuelDeath()
    {
       
        SceneManager.LoadScene("MainScene");
        fuelDeathpanel.SetActive(false);
    }
    private void fuelDeathMessage()
    {
        fuelDeathpanel.SetActive(true);
    }
    public void addFuel(int amt)
    {
        Fuel += amt;
    }
    public void addMoney(int amt)
    {
        Money += amt;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            LastHit = 0;
            Health -= 10;
            GameObject.Find("StyleManager").GetComponent<Style>().RemoveStyle(100);
            collision.gameObject.GetComponent<MeteorController>().Die();
        }
        if (collision.gameObject.tag == "Fuel")
        {
            npm.enable(2);
           
            collision.gameObject.GetComponent<MeteorController>().Die();
        }
        if (collision.gameObject.tag == "Normal")
        {
            npm.enable(1);
            
            collision.gameObject.GetComponent<MeteorController>().Die();
        }
    }

    void Tick()
    {
        Fuel -= 0.7f;
    }
    
}
