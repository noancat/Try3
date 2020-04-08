using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LetMeGo : MonoBehaviour
{
    // Start is called before the first frame update
    private float waittime, starttime;
    public bool letme;
    public Animator letmegofrom;
    public void Start()
    {
        starttime = 3f;
        waittime = starttime;
        letme = false;
        letmegofrom = GetComponent<Animator>();
        letmegofrom.SetInteger("comp",0);
        letmegofrom.SetBool("vir",false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        letme = true;
        Debug.Log("seeu");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        letme = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (letme)
        {
            if (waittime <= 0)
            {
                letmegofrom.SetBool("vir", true);
                waittime = starttime;
            }
            else
            {
                waittime -= Time.deltaTime;
            }
        }
        else
        {
            letmegofrom.SetBool("vir", false);
        }
       
      
    }
}
