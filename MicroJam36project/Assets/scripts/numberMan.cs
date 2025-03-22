using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberMan : MonoBehaviour
{
    [SerializeField]
    private GameObject numberContainer;
    public int amount = 3;
    [SerializeField]
    private GameObject number;
    private bool enabled = false;
    // Start is called before the first frame update
    void Start()
    {
        enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void disable()
    {
        enabled = false;
        numberContainer.SetActive(false);
    }
    public void enable()
    {
        enabled = true;
        numberContainer.SetActive(true);
        generateNums();
    }
    public void generateNums()
    {
        for(int i = 0; i < amount; i++)
        {
            Instantiate(number, new Vector2(numberContainer.transform.position.x + (80 * i), numberContainer.transform.position.y), numberContainer.transform.rotation, numberContainer.transform);
        }
       
    }
}
