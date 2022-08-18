using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject groundCheck;
    [SerializeField] private LayerMask jumpableGround;
    public GameObject gamemaster;
    private GameMaster gm;
    public float Speed = 5f;
    public int jumpForce = 5;
    public float sprintMultiplyer = 3f;
    public bool isGrounded = false;
    public bool isSprinting = false;

    public GameObject PauseMenu;
    Rigidbody2D rb2d;

    Animator animator;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;

        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            if (isSprinting)
            {
                rb2d.velocity = new Vector2(Speed*sprintMultiplyer, rb2d.velocity.y);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            if (isSprinting)
            {
                rb2d.velocity = new Vector2(-Speed*sprintMultiplyer, rb2d.velocity.y);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                rb2d.velocity = new Vector2(-Speed, rb2d.velocity.y);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Input.GetKey("w") && IsGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }

        bool Moving = Input.GetKey("left") || Input.GetKey("a") || Input.GetKey("right") || Input.GetKey("d");
        animator.SetBool("Moving", Moving);

        bool Grounded = IsGrounded();
        animator.SetBool("Grounded", Grounded);

        
        bool Shoot = Input.GetButton("Fire1");
        animator.SetBool("Shoot", Shoot);
        

        if (Input.GetKeyDown("r"))
        {
            transform.position = gm.lastCheckPointPos;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

    private bool IsGrounded()
    {
        BoxCollider2D coll = groundCheck.GetComponent<BoxCollider2D>();
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }




}
