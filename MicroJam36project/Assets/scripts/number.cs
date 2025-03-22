using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class number : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void setNum(string s)
    {
        text.text = s;
    }
    public void setCol()
    {
        Image img = this.GetComponent<Image>();
        img.color = UnityEngine.Color.green;
    }
    public void kill()
    {
        Image img = this.GetComponent<Image>();
        img.color = UnityEngine.Color.red;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
