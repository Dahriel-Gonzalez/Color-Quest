using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeHive : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach(GameObject bee in GameObject.FindGameObjectsWithTag("Bee"))
            {
                bee.GetComponent<beeBehavior>().setAngry();
            }
        }
    }
}
