using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelController : MonoBehaviour
{
    public List<Level> levels;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        levels = new List<Level>
        {
            new Level(0, "Yellow1", false, false),
            new Level(1, "Yellow2", false, true),
            new Level(2, "Yellow3", false, true),
            new Level(3, "Yellow4", false, true),
            new Level(4, "Yellow5", false, true),
            new Level(5, "Green1", false, true),
            new Level(6, "Green2", false, true),
            new Level(7, "Green3", false, true),
            new Level(8, "Green4", false, true),
            new Level(9, "Green5", false, true),
            new Level(10, "Blue1", false, true),
            new Level(11, "Blue2", false, true),
            new Level(12, "Blue3", false, true),
            new Level(13, "Blue4", false, true),
            new Level(14, "Blue5", false, true),
            //new Level(15, "Orange", false, true),
            //new Level(16, "Orange2", false, true),
            //new Level(17, "Orange3", false, true),
            //new Level(18, "Orange4", false, true),
            //new Level(19, "Orange5", false, true),
            new Level(20, "Indigo1", false, true),
            new Level(21, "Indigo2", false, true),
            new Level(22, "Indigo3", false, true),
            new Level(23, "Indigo4", false, true),
            new Level(24, "Indigo5", false, true),
            //new Level(25, "Purple", false, true),
            //new Level(26, "Purple2", false, true),
            //new Level(27, "Purple3", false, true),
            //new Level(28, "Purple4", false, true),
            //new Level(29, "Purple5", false, true),
            new Level(30, "Red1", false, true),
            new Level(31, "Red2", false, true),
            new Level(32, "Red3", false, true),
            new Level(33, "Red4", false, true),
            new Level(34, "Red5", false, true),
        };
    }

    public void StartLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void CompleteLevel(string levelName)
    {
        levels.Find(i => i.LevelName == levelName).Complete();
    }

    public bool checkUnlock(string levelName)
    {
        return (levels.Find(i => i.LevelName == levelName).Locked);
    }

    public void unlockLevel(string levelName)
    {
        print("attempt");
        levels.Find(i => i.LevelName == levelName).Unlock();
    }
}


