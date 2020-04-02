using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Patrol : MonoBehaviour

{
    // Start is called before the first frame update
    public float speed;
    private float waitTime;
    private float waittime2, dethTime;
    public float startTime;
    private int Arrayindex;
    public bool isDead;

    public BoxCollider2D bc2d;
    public Transform[] moveSpots;
    public Transform startLine, endLine;
    public Transform stayRightStart, stayRightEnd, stayLeftStart, stayLeftEnd;
    public Animator anima;
    public GameObject arrowAlarm, arrowLeftRight, arrowMain;

    private Rigidbody2D rb;
    public bool spotedByRun;
    public bool staySpottedLeft;
    public bool staySpottedRight;
    public static float currSpeed;
    public float h;
    public bool chill = false;
    public bool eventBool;
    public float dist = 0.2f;
    Vector2 currTurn;
    Vector2 lastTurnzero;
    Vector2 lastTurnonehs;

    void Start()
    {
        lastTurnzero = new Vector2(0, 0);
        lastTurnonehs = new Vector2(0, 180);
        startTime = 4f;
        isDead = false;
        waittime2 = 2f;
        waitTime = startTime;
        Arrayindex = 0;
        bc2d = GetComponent<BoxCollider2D>();
        anima = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
        arrowLeftRight.SetActive(true);
        arrowMain.SetActive(true);
        currSpeed = 10f;
        dethTime = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && !Move.dead)
        {
            isDead = true;
            Move.spotted = false;
            Move.speed = 40f;
            speed = 0;
            bc2d.enabled = false;
            rb.gravityScale = 0;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    public void Deth()
    {
        arrowAlarm.SetActive(false);
        arrowLeftRight.SetActive(false);
        arrowMain.SetActive(false);
        anima.SetInteger("guard_stat", 6);

        dethTime += Time.deltaTime;
        if (dethTime >= 4)
        {
            anima.SetInteger("guard_stat", 7);
        }

    }
    void Update()
    {

        if (isDead)
        {
            Deth();
            return;
        }
        else
        {
            bc2d.enabled = true;
        }
        if (Move.patrolAlarm)
        {
            currSpeed = 40f;
        }
        else
        {
            currSpeed = 10f;
        }
        if (waitTime <= 0)
        {
            ChekPoint();
            waitTime = startTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
        if (Vector2.Distance(transform.position,
            moveSpots[Arrayindex].transform.position) < dist)
        {

            staySpottedLeft = Physics2D.Linecast(stayRightStart.position,
                stayLeftEnd.position, 1 << LayerMask.NameToLayer("Player_layer"));
            staySpottedRight = Physics2D.Linecast(stayRightStart.position,
                stayRightEnd.position, 1 << LayerMask.NameToLayer("Player_layer"));
            anima.SetInteger("guard_stat", 0);
            chill = true;
            arrowLeftRight.SetActive(true);
            arrowMain.SetActive(false);
        }
        else
        {
            Debug.DrawLine(startLine.position, endLine.position,
                Color.green);
            spotedByRun = Physics2D.Linecast(startLine.position,
                endLine.position, 1 << LayerMask.NameToLayer("Player_layer"));
            anima.SetInteger("guard_stat", 1);
            chill = false;
            arrowMain.SetActive(true);
            arrowLeftRight.SetActive(false);
            staySpottedLeft = false;
            staySpottedRight = false;
        }
        if (chill)
        {
            Debug.DrawLine(stayRightStart.position,
                stayRightEnd.position, Color.red);
            Debug.DrawLine(stayLeftStart.position,
                stayLeftEnd.position, Color.blue);
            transform.eulerAngles = lastTurnonehs;
            staySpottedRight =
                Physics2D.Linecast(stayRightStart.position, stayRightEnd.position,
                1 << LayerMask.NameToLayer("Player_layer"));
            staySpottedLeft = Physics2D.Linecast(stayLeftStart.position, stayLeftEnd.position,
                1 << LayerMask.NameToLayer("Player_layer"));
        }
        else
        {
            transform.eulerAngles = currTurn;
        }

        transform.position =
            Vector2.MoveTowards(transform.position,
            moveSpots[Arrayindex].transform.position, speed * Time.deltaTime);
        if (Move.dead)
        {
            staySpottedLeft = false;
            staySpottedRight = false;
            spotedByRun = false;
        }
        Spotted();
        StayWath();
    }

    void ChekPoint()
    {
        int test = Arrayindex + 1;
        if (Vector2.Distance(transform.position,
            moveSpots[Arrayindex].transform.position) < dist)
        {
            if (test > 1)
            {
                Arrayindex = 0;
            }
            else
            {
                Arrayindex++;
            }
            if (Arrayindex == 0)
            {
                transform.eulerAngles = lastTurnzero;
                currTurn = lastTurnzero;
            }
            if (Arrayindex == 1)
            {
                transform.eulerAngles = lastTurnonehs;
                currTurn = lastTurnonehs;
            }
        }
    }
    void Spotted()
    {
        Move.spotted = false;
        if (spotedByRun || staySpottedLeft || staySpottedRight)
        {
            Move.spotted = true;
            arrowAlarm.SetActive(true);
            speed = 0; waitTime = startTime;
            anima.SetInteger("guard_stat", 4);

            if (waittime2 <= 0)
            {
                anima.SetInteger("guard_stat", 5);
                Hpbar.fill -= Time.deltaTime * 0.1f;
            }
            else
            {
                waittime2 -= Time.deltaTime;
            }
        }
        else
        {

            arrowAlarm.SetActive(false);
            speed = currSpeed;
        }
    }
    void StayWath()
    {
        if (staySpottedLeft)
        {
            transform.eulerAngles = lastTurnonehs;
            spotedByRun = false;
        }
        if (staySpottedRight)
        {
            spotedByRun = false;
            transform.eulerAngles = lastTurnzero;

        }
        if (spotedByRun)
        {
            staySpottedLeft = false;
            staySpottedRight = false;
        }
    }
    public void LoadDate(Save.SaveDate save)
    {
        transform.position = new Vector2(save.Position.x, save.Position.y);
        isDead = save.Live;

    }
}
