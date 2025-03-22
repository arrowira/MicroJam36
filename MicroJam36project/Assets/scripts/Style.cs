using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Style : MonoBehaviour
{
    private float PStyle = 0;
    int LastGained = 0;
    [SerializeField]
    private TMP_Text rank;
    public float styleRank = 0;
    [SerializeField]
    private Image styleBar;
    public float Combo = 0;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        styleBar.fillAmount = 1.0f-((PStyle%416)/416);
        styleRank = PStyle / 416.0f;
        if(styleRank < 1)
        {
            rank.text = "F";
        }else if(styleRank < 2.0f)
        {
            rank.text = "D";
        }else if (styleRank < 3.0f)
        {
            rank.text = "C";
        }else if (styleRank < 4.0f)
        {
            rank.text = "B";
        }else if (styleRank < 5.0f)
        {
            rank.text = "A";
        }
        else
        {
            rank.text = "S";
        }

        int Lh = GameObject.Find("playerManager").transform.Find("player").GetComponent<playerMovement>().LastHit;
        int Lf = GameObject.Find("Canvas").transform.Find("numberPanelManager").GetComponent<numberMan>().LastFailed;
        LastGained += 1;
        if(LastGained >= 50 && PStyle >= 0)
        {
            PStyle -= Random.Range(0, 2);
        }
        Debug.Log(PStyle);
    }

    public void Addstyle(int amount)
    {
        PStyle += amount*Combo;
        LastGained = 0;
        Combo += 1 - (Combo / 10);
    }

    public void RemoveStyle(int amount)
    {
        PStyle -= amount;
        if(PStyle <= 0)
        {
            PStyle = 0;
        }
        Combo = 1;
    }
}
