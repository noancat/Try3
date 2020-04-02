using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PolimorfScript
{
    public static bool coinb;
    public GameObject card;

    public override void Use()
    {
        coinb = true;
        card.SetActive(true);
        base.Use();
        card.SetActive(true);
    }
    public new void Start()
    {
        coinb = false;
        card.SetActive(false);
        GameManager.GetInstance().cardPicked += Use;
    }
    private void FixedUpdate()
    {
       
        if (coinb)
        {
            GameManager.GetInstance().CardIsGet();
            Destroy(gameObject);
        }
    }
}

