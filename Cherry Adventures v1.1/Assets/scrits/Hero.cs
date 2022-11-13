using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float speed = 5f;
    public float JumpForce = 15f;
    private Animator anim;
    public Vector2 moveVector;

    [SerializeField] public bool tF = true;


    Rigidbody2D rb;
    SpriteRenderer sprite;

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();

    }
    public void Artur(bool a)
    {
        tF = a;
    }
    private void Update()
    {
        if (onGround) State = States.idle;

        if (tF == true)
        {
            moveVector.x = Input.GetAxis("Horizontal");
            CheckingGround();
            Jump();
            if (Input.GetButton("Horizontal"))
                Run();
        }
    }

    private void Run()
    {
        if (onGround) State = States.run;
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {

            rb.AddForce(Vector3.up * JumpForce);
        }
    }

    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);

        if (!onGround) State = States.jump;
    }
}
public enum States
{
    idle,
    run,
    jump
}