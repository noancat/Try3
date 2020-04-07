using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessCard : PolimorfScript
{
    public static bool coinPikced;
    public GameObject card;

    public override void Use()
    {
        coinPikced = true;
        card.SetActive(true);
        base.Use();
        card.SetActive(true);
    }
    public new void Start()
    {
        coinPikced = false;
        card.SetActive(false);
        GameManager.GetInstance().cardPicked += Use;
    }
    private void FixedUpdate()
    {
        if (coinPikced)
        {
            GameManager.GetInstance().CardIsGet();
            Destroy(gameObject);
        }
    }
}

