using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LetMeGo : MonoBehaviour
{
    // Start is called before the first frame update
    private float waitTime, startTime;
    public bool onTrigger;
    public Animator letmegofrom;
    public void Start()
    {
        startTime = 3f;
        waitTime = startTime;
        onTrigger = false;
        letmegofrom = GetComponent<Animator>();
        letmegofrom.SetInteger("comp",0);
        letmegofrom.SetBool("vir",false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.GetInstance().player.gameObject)
        {
            onTrigger = true;
            Debug.Log("seeu");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.GetInstance().player.gameObject)
        {
            onTrigger = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (onTrigger)
        {
            if (waitTime <= 0)
            {
                letmegofrom.SetBool("vir", true);
                waitTime = startTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            letmegofrom.SetBool("vir", false);
        }
       
      
    }
}
