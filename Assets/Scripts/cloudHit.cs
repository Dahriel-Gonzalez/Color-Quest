using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudHit : MonoBehaviour
{
    bool hb;
    GameObject flower;
    GameObject rain;
    ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.Pause();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hb = collision.gameObject.GetComponent<playerController>().hb;
            if (hb)
            {
                flower = GameObject.FindGameObjectsWithTag("Flower")[0];
                flower.GetComponent<flowerBloom>().Bloom();
                ps.Play();
            }
        }
    }
}
