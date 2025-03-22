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
    public bool enabled = false;
    private List<GameObject> numbers = new List<GameObject>();
    private string s;
    private int pos = 0;
    Event e;
    private int difficulty = 0;
    bool keydown = false;
    [SerializeField]
    playerMovement pm;
    private int astroidType = 0;
    //0 is none. 1 is money. 2 is fuel

    AudioSource CorrectSound;
    AudioSource PressSound;
    AudioSource ErrorSound;

    public int LastFailed;
    void Start()
    {
        CorrectSound = GetComponent<AudioSource>();
        PressSound = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        ErrorSound = GameObject.Find("AudioManager").transform.Find("ErrorSound").GetComponent<AudioSource>();
    }
    void OnGUI()
    {
        if (enabled)
        {
            e = Event.current;
            if (e.type.Equals(EventType.KeyDown))
            {

                keydown = true;

                if (e.keyCode.ToString() == "Alpha" + s[pos].ToString())
                {
                    PressSound.Play();
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
                    LastFailed = 0;
                    GameObject.Find("StyleManager").GetComponent<Style>().RemoveStyle(50);
                    Invoke("PlayES", 0.13f);
                    for (int i = 0; i < amount; i++)
                    {
                        numbers[i].GetComponent<number>().kill();
                    }
                    Time.timeScale = 1.0f;
                    Invoke("disable", 0.1f);
                }


                if (pos == amount)
                {
                    Time.timeScale = 1.0f;
                    Invoke("PlayCS", 0.13f);
                    GameObject.Find("StyleManager").GetComponent<Style>().Addstyle(50);
                    //correctly solved
                    if(astroidType== 1)
                    {
                        pm.addMoney(10);
                        pm.addScore(10);
                    }
                    else if (astroidType== 2)
                    {
                        pm.addFuel(10);
                        pm.addScore(5);
                    }
                    
                    Invoke("disable", 0.1f);
                }
            }

            if (e.type.Equals(EventType.KeyUp))
                keydown = false;
        }
        
    }
    void FixedUpdate()
    {
        LastFailed += 1;
    }
    public void disable()
    {
        Time.timeScale = 1.0f;
        for (int i = 0; i < numbers.Count; i++)
        {
            Destroy(numbers[i]);
        }
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
    public void enable(int x)
    {
        astroidType= x;
        disable();
        numbers = new List<GameObject>();
        transform.position = new Vector2(Screen.width*0.5f+40, 200);
        Time.timeScale = 1.0f;
        pos = 0;
        amount = Random.Range(2+difficulty, 5+difficulty);
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
    void PlayCS()
    {
        CorrectSound.Play();
    }
    void PlayES()
    {
        ErrorSound.Play();
    }
}
