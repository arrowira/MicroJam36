using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberMan : MonoBehaviour
{
    [SerializeField]
    private GameObject numberContainer;
    public int amount;
    [SerializeField]
    private GameObject number;
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
        numberContainer.SetActive(false);
    }
    public void enable()
    {
        numberContainer.SetActive(true);
        generateNums();
    }
    public void generateNums()
    {
        Instantiate(number, new Vector2(0,0), transform.rotation, numberContainer.transform);
    }
}
