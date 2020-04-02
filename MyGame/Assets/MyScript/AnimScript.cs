using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("fin",false);
       
    }
    void SetAnimateTrue()
    {
        anim.SetBool("fin", false);
    }
    public void FixedUpdate()
    {
        if (Hpbar.fill <=0)
        {
            anim.SetInteger("new",5);
        }else
        if (!(Move.isGrounded))
        {
            anim.SetInteger("new", 3);
        }
        else if (Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D) || 
            Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow) ||
            Move.h > 0 || Move.h < 0)
        {
            anim.SetInteger("new", 1);
        }
        else
        {
            anim.SetInteger("new", 0);

        }  
    }

}
//Хасан Гома UML роэктирование систем реального
//бвнда четырех паттерны проэктирования SINGLTONE