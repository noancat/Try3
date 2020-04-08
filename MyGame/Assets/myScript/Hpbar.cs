using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image bar;
    public static float fill;
    // public static bool smert;
    void Start()
    {
        fill = 1f;

    }
    void Update()
    {
        bar.fillAmount = fill;
    }

}
