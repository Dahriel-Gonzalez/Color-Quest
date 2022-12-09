using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    public Transform feet;
    public bool hb = false;
    public bool invincible = false;

    public float speed = 40f;
    public float maxSpeed = 3f;
    public Joystick joystick;
    public float horizontalMove = 0;

    //jumping
    float touchStart;
    LayerMask groundLayer;
    bool grounded;
    float lastGrounded;
    bool tap;
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;
    float coyoteTime = 0.1f;
    public float jumpSpeed = 12f;

    //dashing
    private bool canDash = true;
    private bool isDashing = false;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCD = 1f;
    float dashType;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //checks
        grounded = Physics2D.OverlapCircle(feet.position, 0.1f, groundLayer);

        //Horizontal Movement
        if (!isDashing)
        {
            if (joystick.Horizontal >= 0.2f)
            {
                horizontalMove = speed;
                anim.SetBool("walking", true);
            }
            else if (joystick.Horizontal <= -0.2f)
            {
                horizontalMove = -speed;
                anim.SetBool("walking", true);
            }
            else
            {
                anim.SetBool("walking", false);
                horizontalMove = 0;
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            //rb.AddForce(new Vector2(horizontalMove, 0));
            Vector3 Move = new Vector3(horizontalMove, 0, 0);
            transform.position += Move * Time.deltaTime * speed;
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y);
            horizontalMove = joystick.Horizontal * speed;
        }

        //Jumping/Dashing 
        if (Input.touches.Length > 0)
        {
            //if (Input.touches.Length == 1 && joystick.Horizontal != 0) { } 
            if (Input.GetTouch(Input.touches.Length - 1).phase == TouchPhase.Began)
            {
                touchStart = Time.time;
                startTouchPos = Input.GetTouch(Input.touches.Length - 1).position;
            }
            if (Input.GetTouch(Input.touches.Length - 1).phase == TouchPhase.Ended && Time.time - touchStart <= 1f)
            {
                endTouchPos = Input.GetTouch(Input.touches.Length - 1).position;
                if ((Mathf.Abs(startTouchPos.x - endTouchPos.x) > 200) || (Mathf.Abs(startTouchPos.y - endTouchPos.y) > 200))
                {
                    if (Mathf.Abs(startTouchPos.x - endTouchPos.x) > Mathf.Abs(startTouchPos.y - endTouchPos.y))
                    {
                        if (endTouchPos.x < startTouchPos.x && canDash)
                        {
                            StartCoroutine(Dash(0));
                        }
                        if (endTouchPos.x > startTouchPos.x && canDash)
                        {
                            StartCoroutine(Dash(1));
                        }
                    }
                    else
                    {
                        if (endTouchPos.y < startTouchPos.y && canDash)
                        {
                            StartCoroutine(Dash(2));
                        }
                        if (endTouchPos.y > startTouchPos.y && canDash)
                        {
                            StartCoroutine(Dash(3));
                        }
                    }
                } else if (Time.time - touchStart <= 0.5f)
                //jumping
                {
                    if (grounded || CheckCoyoteTime())
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                        lastGrounded = 0f;
                    }
                }
            }
        }
        if (grounded)
        {
            lastGrounded = Time.time;
            anim.SetTrigger("grounded");
        } //else
        //{
            //anim.SetBool("grounded", false);
        //}
        //Input.GetTouch(Input.touches.Length - 1).phase == TouchPhase.Began
        //if (grounded && Input.GetTouch(Input.touches.Length - 1).phase == TouchPhase.Began)
    }

    private IEnumerator Dash(float type)
    {
        canDash = false;
        isDashing = true;
        float oGravity = rb.gravityScale;
        float oSpeed = maxSpeed;
        maxSpeed = 100f;
        rb.gravityScale = 0f;
        if (type == 0)
        {
            //dash left
            anim.SetTrigger("jump");
            rb.velocity = new Vector2(-dashingPower, 0f);
        } else if (type == 1)
        {
            //dash right
            anim.SetTrigger("jump");
            rb.velocity = new Vector2(dashingPower, 0f);
        } else if (type == 2)
        {
            //ground pound
            anim.SetTrigger("grounded");
            rb.velocity = new Vector2(0f, 0f);
            hb = true;
            yield return new WaitForSeconds(dashingTime);
            rb.velocity = new Vector2(0f, -dashingPower/2);
        } else if (type == 3)
        {
            //dash up
            anim.SetTrigger("jump");
            rb.velocity = new Vector2(0f, dashingPower/2);
        }
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = oGravity;
        maxSpeed = oSpeed;
        isDashing = false;
        yield return new WaitForSeconds(dashingCD);
        hb = false;
        canDash = true;
    }

    bool CheckCoyoteTime()
    {
        return (Time.time - lastGrounded < coyoteTime);
    }
}
