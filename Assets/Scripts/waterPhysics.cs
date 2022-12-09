using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterPhysics : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Rigidbody2D>().gravityScale = 0.8f;
        player.GetComponent<playerController>().jumpSpeed /= 1.33f;
        player.GetComponent<playerController>().dashingPower /= 2;
        player.GetComponent<playerController>().speed /= 1.2f;
        player.GetComponent<playerController>().maxSpeed /= 1.2f;
    }
}
