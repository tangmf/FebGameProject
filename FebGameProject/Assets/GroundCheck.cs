using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject Player;
    private int enteredGrounds = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            enteredGrounds++;
            if (enteredGrounds > 0)
            {
                Player.GetComponent<PlayerMovement>().isGrounded = true;
            }
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            enteredGrounds--;
            if (enteredGrounds <= 0)
            {
                enteredGrounds = 0;
                Player.GetComponent<PlayerMovement>().isGrounded = false;
            }
        }
    }
}
