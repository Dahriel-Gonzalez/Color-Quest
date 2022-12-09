using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    public bool paused;
    public string menu = "Main Menu";
    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
    }
    public void reload()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void loadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menu);
    }
    public void pause()
    {
        Time.timeScale = 0f;
        paused = true;
    }
    public void unpause()
    {
        Time.timeScale = 1f;
        paused = false;
    }
}
