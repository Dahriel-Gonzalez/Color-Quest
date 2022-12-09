using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public float spawnRate;
    public bool active;
    private float timer;
    public GameObject[] spawnType;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active && timer < 0 )
        {
            int position = Random.Range(0, spawnType.Length);
            Instantiate(spawnType[position], transform.position, Quaternion.identity);
            print("spawned");
            timer = spawnRate;
        } else
        {
            timer -= Time.deltaTime;
        }
    }
}
