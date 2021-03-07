using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject gamemaster;
    private GameMaster gm;
    public float Speed = 5f;
    public int jumpForce = 10;
    public bool isGrounded = false;

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
            rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-Speed, rb2d.velocity.y);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Input.GetKey("w") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

        }

        if (Input.GetKeyDown("p"))
        {
            if (PauseMenu.activeSelf)
            {
                PauseMenu.SetActive(false);
                Debug.Log("Menu closed");
            }
            else
            {
                PauseMenu.SetActive(true);
                Debug.Log("Menu opened");
            }


        }

        bool Moving = Input.GetKey("left") || Input.GetKey("a") || Input.GetKey("right") || Input.GetKey("d");
        animator.SetBool("Moving", Moving);

        bool Grounded = isGrounded;
        animator.SetBool("Grounded", Grounded);

        bool Shoot = Input.GetKey(KeyCode.Space);
        animator.SetBool("Shoot", Shoot);

        if (Input.GetKeyDown("r"))
        {
            transform.position = gm.lastCheckPointPos;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        Destroy(gamemaster);
    }



}
