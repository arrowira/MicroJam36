using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class deathtext : MonoBehaviour
{
    [SerializeField]
    playerMovement pm;
    [SerializeField]
    TMP_Text score;
    [SerializeField]
    TMP_Text money;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        money.text = pm.Money.ToString();
        score.text = pm.Score.ToString();


    }
}
