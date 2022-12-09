using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerBloom : MonoBehaviour
{
    bool green;
    public SpriteRenderer spriteRenderer;
    public Sprite gFlower;
    public Sprite stem;
    public Sprite flower;
    // Start is called before the first frame update
    void Start()
    {
        if (green)
        {
            spriteRenderer.sprite = stem;
        }
    }

    // Update is called once per frame
    public void Bloom()
    {
        StartCoroutine(Wait());
        
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        spriteRenderer.sprite = gFlower;
        if (green)
        {
            spriteRenderer.sprite = flower;
        }
        foreach (GameObject bee in GameObject.FindGameObjectsWithTag("Bee"))
        {
            bee.GetComponent<beeBehavior>().setPollenating();
            bee.GetComponent<beeBehavior>().unsetIdle();
        }
    }
}
