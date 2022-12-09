using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteCloud : MonoBehaviour
{
    bool hb;
    Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hb = collision.gameObject.GetComponent<playerController>().hb;
            if (hb)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                anim.SetTrigger("Hit");
            }
        }
    }


}
