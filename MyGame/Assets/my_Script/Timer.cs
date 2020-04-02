using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text gameTimerText;
    public  float GameTimer;
    public string timeString;
    private void Start()
    {
        GameTimer = 300f;
        GameManager.GetInstance().cardPicked += PlusTime;
    }
    public void PlusTime()
    {
        GameTimer += 60f;
    }
    public void Update()
    {
        GameTimer -= Time.deltaTime;
        int second = (int)(GameTimer % 60);
        int minutes = (int)(GameTimer / 60) % 60;
        int hours = (int)(GameTimer / 3600) % 24;

       timeString = string.Format("{1:00}:{2:00}",hours,minutes,second);

        gameTimerText.text = timeString;
        if (GameTimer <= 0)
        {
            Move.dead = true;
        }
    }
}
