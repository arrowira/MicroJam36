using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Style : MonoBehaviour
{
    int PStyle = 0;
    int LastGained;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        int Lh = GameObject.Find("playerManager").transform.Find("player").GetComponent<playerMovement>().LastHit;
        int Lf = GameObject.Find("Canvas").transform.Find("numberPanelManager").GetComponent<numberMan>().LastFailed;
        LastGained += 1;
        if (Lh > 100 && Lh > 50)
        {
            if (Random.Range(1, 1001) >= LastGained)
            {
                Addstyle(1);
            }
        }
        if(LastGained >= 50)
        {
            if(Lh < 300 && Lf < 120)
            {
                if(GameObject.Find("playerManager").transform.Find("player").GetComponent<Rigidbody2D>().velocity.magnitude >= 0.1f)
                {
                    RemoveStyle(Random.Range(0, 2));
                }
                RemoveStyle((int)LastGained / 100);
            }
        }
        Debug.Log(PStyle);
    }

    public void Addstyle(int amount)
    {
        PStyle += amount;
        LastGained = 0;
    }

    public void RemoveStyle(int amount)
    {
        PStyle -= amount;
        if(PStyle <= 0)
        {
            PStyle = 0;
        }
    }
}
