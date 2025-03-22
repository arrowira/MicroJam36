using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberMan : MonoBehaviour
{
    [SerializeField]
    private GameObject numberContainer;
    // Start is called before the first frame update
    void Start()
    {
        disable();
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
        numberContainer.SetActive(false);
    }
}
