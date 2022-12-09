using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int ID { get; set; }
    public string LevelName { get; set; }
    public bool Completed { get; set; }
    public bool Locked { get; set; }

    public Level(int id, string levelName, bool completed, bool locked)
    {
        ID = id;
        LevelName = levelName;
        Completed = completed;
        Locked = locked;
    }

    public void Complete()
    {
        Completed = true;
    }

    public void Lock()
    {
        this.Locked = true;
    }

    public void Unlock()
    {
        print("something");
        Locked = false;
    }
}
