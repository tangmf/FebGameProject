using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed= 50;
    private Transform target;
    public GameObject detection;
    private SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetPlayer() && target)
        {
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (transform.position.x <= target.position.x)
            {

                transform.eulerAngles = new Vector3(0, 180, 0);
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
            else
            {

                transform.eulerAngles = new Vector3(0, 0, 0);
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            }
            
        }
        
    }

    public bool TargetPlayer()
    {
        if (detection.GetComponent<EnemyAI>().playerDetect)
        {
            Debug.Log("targetting player");
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            return true;
        }
        else
        {
            return false;
        }
        
    }

}
