using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHitBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("here");
            if (collision.gameObject.GetComponent<playerController>().invincible == false)
            {
                print("should");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            } else
            {
                //Die
                print("why");
                Destroy(gameObject);
            }
        }
    }
}
