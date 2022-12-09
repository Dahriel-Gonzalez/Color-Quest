using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Optionspanel;
    // Start is called before the first frame update
    void Start()
    {
        Optionspanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void enablePanel()
    {
        Optionspanel.SetActive(true);
    }

    void disablePanel()
    {
        Optionspanel.SetActive(false);
    }
}
