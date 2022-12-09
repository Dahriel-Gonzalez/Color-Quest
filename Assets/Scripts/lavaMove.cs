using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaMove : MonoBehaviour
{
    public Vector2 targetA = new Vector2(0, 0);
    private Vector2 targetB;
    public bool towardsA = true;
    public bool retracts = true;
    public float speed;
    void Start()
    {
        if (targetA == new Vector2(0,0))
        {
            targetA = new Vector2(transform.position.x - 1.5f, transform.position.y + 1.5f);
        } else
        {
            targetA = new Vector2(transform.position.x + targetA.x, transform.position.y + targetA.y);
        }
        targetB = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, targetA) < 0.5f)
        {
            towardsA = false;
        } else if (Vector2.Distance(transform.position, targetB) < 0.5f)
        {
            towardsA = true;
        }
        if (towardsA)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetA, speed * Time.deltaTime);
        } else if (retracts)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetB, speed * Time.deltaTime);
        }
    }
}
