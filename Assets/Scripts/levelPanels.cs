using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelPanels : MonoBehaviour
{
    private int currPanel = 0;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currPanel == 1)
        {
            panel1.SetActive(true);
            panel2.SetActive(false);
            panel3.SetActive(false);
        } else if (currPanel == 2)
        {
            panel2.SetActive(true);
            panel1.SetActive(false);
            panel3.SetActive(false);
        } else if (currPanel == 3)
        {
            panel3.SetActive(true);
            panel2.SetActive(false);
            panel1.SetActive(false);
        } else
        {
            panel1.SetActive(false);
            panel2.SetActive(false);
            panel3.SetActive(false);
            x.SetActive(false);
        }

        if (currPanel != 0)
        {
            x.SetActive(true);
        }
    }
    public void rightPanel()
    {
        currPanel++;
        if (currPanel == 4)
        {
            currPanel = 1;
        }
    }
    public void leftPanel()
    {
        currPanel--;
        if (currPanel == 0)
        {
            currPanel = 3;
        }
    }
    public void closePanels()
    {
        currPanel = 0;
    }
}
