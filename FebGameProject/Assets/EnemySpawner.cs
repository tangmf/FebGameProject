using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    private float nextActionTime = 0.0f;
    public float cooldown = 1f;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);

            nextActionTime = Time.time + cooldown;

        }
    }
}
