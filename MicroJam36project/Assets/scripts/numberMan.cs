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
    private List<GameObject> numbers = new List<GameObject>();
    private string s;
    private int pos = 0;
    Event e;
    private int difficulty = 0;
    bool keydown = false;
    // Start is called before the first frame update
    void Start()
    {
        enable();
    }
    void OnGUI()
    {
        if (enabled)
        {
            e = Event.current;
            if (e.type.Equals(EventType.KeyDown) && !keydown)
            {

                keydown = true;

                if (e.keyCode.ToString() == "Alpha" + s[pos].ToString())
                {

                    //correct
                    numbers[pos].GetComponent<number>().setCol();
                    pos++;

                }
                else if (e.keyCode.ToString() == "Alpha0" ||
                    e.keyCode.ToString() == "Alpha1" ||
                    e.keyCode.ToString() == "Alpha2" ||
                    e.keyCode.ToString() == "Alpha3" ||
                    e.keyCode.ToString() == "Alpha4" ||
                    e.keyCode.ToString() == "Alpha5" ||
                    e.keyCode.ToString() == "Alpha6" ||
                    e.keyCode.ToString() == "Alpha7" ||
                    e.keyCode.ToString() == "Alpha8" ||
                    e.keyCode.ToString() == "Alpha9")
                {
                    //mistake
                    for (int i = 0; i < amount; i++)
                    {
                        numbers[i].GetComponent<number>().kill();
                    }
                    Invoke("disable", 0.1f);
                }


                if (pos == amount)
                {
                    //correctly solved
                    Invoke("disable", 0.1f);
                }
            }

            if (e.type.Equals(EventType.KeyUp))
                keydown = false;
        }
        
    }
    
    public void disable()
    {
        Time.timeScale = 1.0f;
        enabled = false;
        numberContainer.SetActive(false);
    }
    private void genS()
    {

        s = "";
        for(int i = 0; i < amount; i++)
        {
            s += Random.Range(0, 10).ToString();
        }
    }
    public void setDifficulty(int dif)
    {
        difficulty = dif;
    }
    public void enable()
    {
        Time.timeScale = 0.2f;
        pos = 0;
        amount = Random.Range(3+difficulty, 10+difficulty);
        transform.position=new Vector2(transform.position.x-(amount*40), transform.position.y);
        genS();
        enabled = true;
        numberContainer.SetActive(true);
        generateNums();
    }
    public void generateNums()
    {
        for(int i = 0; i < amount; i++)
        {
            
            numbers.Add(Instantiate(number, new Vector2(numberContainer.transform.position.x + (80 * i), numberContainer.transform.position.y), numberContainer.transform.rotation, numberContainer.transform));
            
            
        }
        
        for(int i = 0; i< amount; i++)
        {
            numbers[i].GetComponent<number>().setNum(s[i].ToString());
        }
       
    }
}
