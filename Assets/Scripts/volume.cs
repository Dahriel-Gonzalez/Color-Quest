using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volume : MonoBehaviour
{
    public Slider slider;
    void Start()
    {
        PlayerPrefs.SetFloat("volume", slider.value = 0.2f);
    }
    public void changeVolume()
    {
        PlayerPrefs.SetFloat("volume", slider.value);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
}
