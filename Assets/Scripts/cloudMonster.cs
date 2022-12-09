using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cloudMonster : MonoBehaviour
{
    public Sprite openMouth;
    public GameObject player;
    public SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > transform.position.y && Mathf.Abs(player.transform.position.x - transform.position.x) < 2)
        {
            spriteRenderer.sprite = openMouth;
        }
    }
}
