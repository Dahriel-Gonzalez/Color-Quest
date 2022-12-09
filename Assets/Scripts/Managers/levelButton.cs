using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelButton : MonoBehaviour
{
    public levelController lvlCtr;
    public string level;
    public bool locked;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        locked = lvlCtr.checkUnlock(level);
        if (locked)
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
        }
    }

    // Update is called once per frame
    public void playLevel()
    {
        lvlCtr.StartLevel(level);
    }
}
