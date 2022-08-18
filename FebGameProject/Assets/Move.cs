using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool activated;
    private Vector2 originalPosition;
    private Vector2 leftPosition;
    private Vector2 rightPosition;
    public float distance = 1.0f;
    public float speed = 1.0f;
    public string currentDirection = "Left";

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
        leftPosition.y = originalPosition.y;
        leftPosition.x = originalPosition.x - distance;
        rightPosition.y = originalPosition.y;
        rightPosition.x = originalPosition.x + distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if(currentDirection == "Left")
            {
                MoveTo("Left");
            }
            else if(currentDirection == "Right")
            {
                MoveTo("Right");
            }
        }
        
    }

    public void MoveTo(string x)
    {
        currentDirection = x;
        if(x == "Left")
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            if(transform.position.x <= leftPosition.x)
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                currentDirection = "Right";
            }
        }
        else if(x == "Right")
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            if (transform.position.x >= rightPosition.x)
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                currentDirection = "Left";
            }
        }
    }

    
}
