using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausescript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel, Pausebutton;
    public GameObject overCanvas, buttonCanvas;

    public void Exit()
    {
        GameManager.GetInstance().LoadScene(0);
    }
    public void Pause()
    {
        Panel.SetActive(true);
        Pausebutton.SetActive(false);
        overCanvas.SetActive(false);
        buttonCanvas.SetActive(false);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Panel.SetActive(false);
        Pausebutton.SetActive(true);
        overCanvas.SetActive(true);
        buttonCanvas.SetActive(true);
        Time.timeScale = 1;
    }
    public void ResStart()
    {
        Time.timeScale = 1;

        GameManager.GetInstance().RestartScene();

    }
    public void FixedUpdate()
    {
        if (Move.dead)
        {
            Pausebutton.SetActive(false);
        }
    }
}
