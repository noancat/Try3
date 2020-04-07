using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    public static float h, v;
    public static float speed;
    public static bool smert = false;
    public float jforce;
    private static Rigidbody2D rb;
    private SpriteRenderer spriteRend;
    public static bool isGrounded;
    public static bool spotted = false;
    public static bool isDead = false;
    public float waitTime;
    public Transform groundCheck;
    public GameObject arrowDeth, buttonConvas;
    public GameObject canv;
    public float checkRadius;
    public LayerMask isitGround;
    public int jump;
    public Text score;
    public bool pointLeft = false;
    public bool pointRight = false;
    public static float positionX, positionY;
    public static bool patrolAlarm;

    // Start is called before the first frame update

    void Start()
    {
        waitTime = 4f;
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        arrowDeth.SetActive(false);
        isDead = false;
        buttonConvas.SetActive(true);
        patrolAlarm = false;
        GameManager.GetInstance().cardPicked += GetPatrolSpeed;
    }
    public void GetPatrolSpeed()
    {
        patrolAlarm = true;
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
        positionX = transform.position.x;
        positionY = transform.position.y;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if (spotted)
        {
            speed = 0;
        }
        else
        {
            speed = 40f;
        }
        if (isDead)
        {
            h = 0;
        }
        if (pointLeft)
        {
            MoveToLeft();
        }
        if (pointRight)
        {
            MoveToRight();
        }
        if (h < 0)
        {
            spriteRend.flipX = true;
        }
        else if (h > 0)
        {
            spriteRend.flipX = false;
        }
        rb.velocity = new Vector2(h * speed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, isitGround);
        Vector3 direction = transform.right * h;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, 2 * Time.deltaTime);

        if (!isGrounded)
        {
            return;
        }
        else
        {
            jump = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jump > 0)
        {
            rb.AddForce(transform.up * jforce, ForceMode2D.Impulse);
            jump--;
        }
        if (Hpbar.fill <= 0)
        {
            Deth();
        }
    }

    public void Jump()
    {
        isGrounded =
            Physics2D.OverlapCircle(groundCheck.position,
            checkRadius, isitGround);
        if (!isGrounded)
        {
            return;
        }
        else
        {
            jump = 1;
        }
        rb.AddForce(transform.up * jforce, ForceMode2D.Impulse);
        jump--;
    }
    public void MoveToLeft()
    {
        pointLeft = true;
        h = -1;
        rb.velocity = new Vector2(h * speed, rb.velocity.y);
        Vector3 direction = transform.right * h;
    }
    public void MoveToRight()
    {
        pointRight = true;
        h = 1;
        rb.velocity = new Vector2(h * speed, rb.velocity.y);
        Vector3 direction = transform.right * h;

    }
    public void Stop()
    {
        h = 0;
        pointLeft = false;
        pointRight = false;

    }
    void Deth()
    {
        buttonConvas.SetActive(false);
        isDead = true;
        rb.bodyType = RigidbodyType2D.Static;
        arrowDeth.SetActive(true);
        canv.SetActive(false);
        if (waitTime <= 0)
        {

            GameManager.GetInstance().RestartScene();
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
    public void LoadDate(Save.SaveDate save)
    {
        transform.position = new Vector2(save.Position.x, save.Position.y);
        isDead = save.Live;
    }
}
