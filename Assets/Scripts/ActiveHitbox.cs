using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveHitbox : MonoBehaviour
{
    public void activate()
    {
        print("on");
        GetComponent<Collider2D>().enabled = true;
    }

    public void deactivate()
    {
        GetComponent<Collider2D>().enabled = false;
    }
}
