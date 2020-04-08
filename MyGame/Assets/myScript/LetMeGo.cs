using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LetMeGo : MonoBehaviour
{
    // Start is called before the first frame update
    private float waitTime, startTime;
    public bool letMe;
    public Animator letMeGoFrom;
    public void Start()
    {
        startTime = 3f;
        waitTime = startTime;
        letMe = false;
        letMeGoFrom = GetComponent<Animator>();
        letMeGoFrom.SetInteger("comp",0);
        letMeGoFrom.SetBool("vir",false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        letMe = true;
        Debug.Log("seeu");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        letMe = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (letMe)
        {
            if (waitTime <= 0)
            {
                letMeGoFrom.SetBool("vir", true);
                waitTime = startTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            letMeGoFrom.SetBool("vir", false);
        } 
    }
}
