using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausescript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel, PauseButton;
    public GameObject overCanvas, buttonCanvas;

    public void Exit()
    {
        GameManager.GetInstance().LoadScene(0);
    }
    public void Pause()
    {
        Panel.SetActive(true);
        PauseButton.SetActive(false);
        overCanvas.SetActive(false);
        buttonCanvas.SetActive(false);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Panel.SetActive(false);
        PauseButton.SetActive(true);
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
        if (PlayerController.isDead)
        {
            PauseButton.SetActive(false);
        }
    }
}
