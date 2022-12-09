using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grayCloud : MonoBehaviour
{
    public float interval = 2;
    public float offset = 0;
    Animator anim;
    private float timer;
    private bool cloudMissing;
    private void Start()
    {
        if (interval < 0.5f)
        {
            interval = 0.5f;
        }
        anim = gameObject.GetComponent<Animator>();
        timer = interval + offset;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {   
            StartCoroutine(Cycle());
            timer = interval;
        }
        if (!cloudMissing)
        {
            timer -= Time.deltaTime;
        }
       
    }

    private IEnumerator Cycle()
    {
        anim.SetTrigger("Poof");
        cloudMissing = true;
        yield return new WaitForSeconds(interval);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        cloudMissing = false;

    }
}
