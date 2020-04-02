using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager:MonoBehaviour
{
    ///singlT_start
    public static GameManager GetInstance()
    {
        return _instance;
    }
    private static GameManager _instance;

    void Awake()
    {
        if (!_instance)
            _instance = this;
        DontDestroyOnLoad(this);
    }
    ///singlT_end
    ///EventSystem_start
    public delegate void Action();
    public event Action cardPicked;

    public void CardIsGet()
    {
        cardPicked();
    }
    ///EventSystem_end
    public Move player;

    public void Exit()
    {
        Application.Quit();
    }
    public void LoadScene(int levl)
    {
        SceneManager.LoadScene(levl);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
