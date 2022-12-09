using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorFall : MonoBehaviour
{
    public float moveSpeed;
    public float variance = 0;
    public float lifespan = 10f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Move = new Vector3(0, moveSpeed, 0);
        transform.position += -1 * Move * Time.deltaTime * Random.Range(moveSpeed - variance, moveSpeed + variance);
        lifespan -= Time.deltaTime;
        if (lifespan < 0)
        {
            Destroy(gameObject);
        }
    }
}
