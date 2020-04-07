using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorScript : PolimorfScript
{
    protected float waitTime;
    public float startTime;
    public Animator anim;

    public bool tapedButton;
    public GameObject roomMe, roomNext;
    public void Start()
    {
        anim = GetComponent<Animator>();
        tapedButton = false;
        anim.SetInteger("door", 0);
        startTime = 1f;
        waitTime = startTime;
    }
    public void Changelevl()
    {
        tapedButton = true;
        anim.SetInteger("door", 1);
    }
    public override void Use()
    {
        roomMe.SetActive(false);
        roomNext.SetActive(true);
        waitTime = startTime;
        tapedButton = false;
        base.Use();
        
    }

    public void FixedUpdate()
    {
        if (tapedButton)
        {
            
            if (waitTime <= 0)
            {
                Use();
                waitTime = startTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
