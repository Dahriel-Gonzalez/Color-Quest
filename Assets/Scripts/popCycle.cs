using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popCycle : MonoBehaviour
{
    public float timing = 1f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("popped");
            StartCoroutine(Cycle());
        }
    }

    private IEnumerator Cycle()
    {
        yield return new WaitForSeconds(timing);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponents<BoxCollider2D>()[0].enabled = false;
        gameObject.GetComponents<BoxCollider2D>()[1].enabled = false;
        yield return new WaitForSeconds(timing*3);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponents<BoxCollider2D>()[0].enabled = true;
        gameObject.GetComponents<BoxCollider2D>()[1].enabled = true;

    }
}
