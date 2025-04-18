using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
    public float Health = 100, Fuel = 100, Score = 0, Money = 0;
    [SerializeField]
    private GameObject fuelDeathpanel;
    [SerializeField]
    private TMP_Text moneyText;
    public int LastHit;
    [SerializeField]
    Style style;
    [SerializeField]
    private TMP_Text scoreNum;
    [SerializeField]
    private GameObject healthDeathPanel;
    [SerializeField]
    private GameObject deathParticles;
    [SerializeField]
    private TMP_Text fuelwarning;
    void Start()
    {
        InvokeRepeating("Tick", 0.3f, 0.3f);
        scoreNum.text = "0";
        moneyText.text = "0";
    }
    void FixedUpdate()
    {
        if (Fuel < 20)
        {
            fuelwarning.enabled = true;
        }
        else
        {
            fuelwarning.enabled = false;
        }
        if (Health > 100)
        {
            Health = 100;
        }
        hpBar.fillAmount = Health / 100.0f;
        powerBar.fillAmount = Fuel / 100.0f;
        if(Fuel > fuelCap)
        {
            Fuel = fuelCap;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * upDownSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector2.up * -upDownSpeed);
        }

        if (Health <= 0)
        {
            //SceneManager.LoadScene("MainScene");
            healthDeathPanel.SetActive(true);
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);

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
       
       
        //fuelDeathpanel.SetActive(false);
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
        moneyText.text = Money.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (npm.enabled)
        {
            npm.disable();
            collision.gameObject.GetComponent<MeteorController>().Die();
            GameObject.Find("StyleManager").GetComponent<Style>().RemoveStyle(416);
        }
        else
        {
            if (collision.gameObject.tag == "Enemy")
            {
                LastHit = 0;
                Health -= 30;
                GameObject.Find("StyleManager").GetComponent<Style>().RemoveStyle(832);
                collision.gameObject.GetComponent<MeteorController>().Die();
            }
            if (collision.gameObject.tag == "Fuel")
            {
                npm.enable(2);

                collision.gameObject.GetComponent<MeteorController>().Drill();
            }
            if (collision.gameObject.tag == "Normal")
            {
                npm.enable(1);
                Money += 10;
                collision.gameObject.GetComponent<MeteorController>().Drill();
            }
            if (collision.gameObject.tag == "Healing")
            {
                Health += 10;
                
                collision.gameObject.GetComponent<MeteorController>().Die();
            }
        }
        
    }
    public void addScore(int amt)
    {
        Score += amt*(style.styleRank+0.5f);
        scoreNum.text = ((int)Score).ToString();
    }
    void Tick()
    {
        Fuel -= 0.47f;
    }
    
}
