using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    float speed;
    private Rigidbody2D rb;
    private float mod;
    bool drilling = false;
    numberMan npm;
    [SerializeField]
    GameObject deathParticles;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float randTurn = Random.Range(-3, 3);
        rb.AddTorque(10 * randTurn);
        
        speed = 0.15f;
        npm = GameObject.Find("numberPanelManager").GetComponent<numberMan>();
        mod = GameObject.Find("MeteorSpawner").GetComponent<MeteorSpawning>().Difficulty;
        if (mod < 3)
        {
            GameObject.Find("numberPanelManager").GetComponent<numberMan>().setDifficulty((int)((mod - 1) * 5));
        }
        
        
    }
    void FixedUpdate()
    {
        if (gameObject.transform.position.x < -50)
        {
            Destroy(gameObject);
        }
        
        //Debug.Log("M: " + mod);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - (speed*mod), gameObject.transform.position.y, -3);
        if (drilling)
        {
            float ranx = Random.Range(-0.06f, 0.06f);
            float rany = Random.Range(-0.06f, 0.06f);
            transform.position = new Vector3(GameObject.Find("drillPosition").transform.position.x+ranx, GameObject.Find("drillPosition").transform.position.y+rany, -3);
           
            if (!npm.enabled)
            {
                Die();
            }
        }

    }
    public void Drill()
    {
        
        drilling = true;
        GetComponent<CircleCollider2D>().enabled = false;
    }
    public void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Die();
        }
    }
}
