using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class beeBehavior : MonoBehaviour
{
    GameObject player;
    GameObject flower;
    public bool angry = false;
    public bool pollenating = false;
    public bool stationary;
    Vector2 target;
    Vector2 starting;
    float lastX;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        flower = GameObject.FindGameObjectWithTag("Flower");
        newTarget();
        starting = new Vector2(transform.position.x, transform.position.y);
        if (stationary)
        {
            GetComponent<Collider2D>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stationary)
        {
            transform.position = Vector2.MoveTowards(transform.position, starting, 8 * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (!angry && !pollenating && !stationary)
        {
            if (Vector2.Distance(transform.position, target) > 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, 8 * Time.deltaTime);
            } else if (Vector2.Distance(transform.position, target) < 1)
            {
                newTarget();
            }
        }
        if (!angry && !stationary)
        {
            GetComponent<Collider2D>().enabled = false;
        }
        if (angry)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 8 * Time.deltaTime);
            GetComponent<Collider2D>().enabled = true;
        } else if (pollenating)
        {
             transform.position = Vector2.MoveTowards(transform.position, new Vector2(flower.transform.position.x, flower.transform.position.y-2), 8 * Time.deltaTime);
        }
        flipCheck();
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Random.Range(transform.position.x - 1, transform.position.x + 1), Random.Range(transform.position.y - 1, transform.position.y + 1)), 8 * Time.deltaTime);
        lastX = transform.position.x;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && angry)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void setAngry()
    {
        angry = true;
    }

    public void setPollenating()
    {
        pollenating = true;
    }

    public void unsetIdle()
    {
        stationary = false;
    }

    private void newTarget()
    {
        target = new Vector2(Random.Range
               (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x), Random.Range
               (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y));
    }

    private void flipCheck()
    {
        if (lastX > transform.position.x && !stationary) {
            GetComponent<SpriteRenderer>().flipX = false;
        } else if (lastX < transform.position.x && !stationary)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
