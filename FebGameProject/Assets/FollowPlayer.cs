using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed;
    private Transform target;
    public bool playerDetect = false;
    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetect)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
    }

    public void TargetPlayer()
    {
        Debug.Log("targetting player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerDetect = true;
    }
}
