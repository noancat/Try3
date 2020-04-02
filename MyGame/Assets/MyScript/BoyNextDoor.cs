using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
public class BoyNextDoor : PolimorfScript
{
    public GameObject noAcces;
    public int indexScene;


    public new void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject == GameManager.GetInstance().player.gameObject && AccessCard.coinPikced)
        {
            doButton.SetActive(true);
            noAcces.SetActive(false);
        }
        else
        {
            doButton.SetActive(false);
            noAcces.SetActive(true);
        }
    }
    public new void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject == GameManager.GetInstance().player.gameObject)
        {
            doButton.SetActive(false);
            noAcces.SetActive(false);
        }
    }
    public override void Use()
    {
        SceneManager.LoadScene(indexScene);
        base.Use();
    }
}
