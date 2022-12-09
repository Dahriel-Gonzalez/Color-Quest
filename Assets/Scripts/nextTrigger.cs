using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextTrigger : MonoBehaviour
{
    public string sceneName;
    //[SerializeField] private levelController lvlCtr;

    void Start()
    {
        //lvlCtr = GameObject.FindGameObjectsWithTag("levelController")[0].GetComponent<levelController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //lvlCtr.unlockLevel(sceneName);
            SceneManager.LoadScene(sceneName);
        }
    }
}
