using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuscript : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Tomenu()
    {
        GameManager.GetInstance().LoadScene(0);
    }
    public void StartGame()
    {
        GameManager.GetInstance().LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
