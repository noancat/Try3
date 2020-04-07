using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PolimorfScript : MonoBehaviour
{
    public GameObject doButton;
    public Text infoText;
    public string newInfo;
    public void Start()
    {
        doButton.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.GetInstance().player.gameObject == other.gameObject)
        {
            doButton.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (GameManager.GetInstance().player.gameObject == other.gameObject)
        {
            doButton.SetActive(false);
        }
    }
    public virtual void Use()
    {
        infoText.text = newInfo;
    }
    public void ButtonClick()
    {
        Use();
    }
}
