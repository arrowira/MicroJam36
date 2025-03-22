using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float upDownSpeed;
    [SerializeField]
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
