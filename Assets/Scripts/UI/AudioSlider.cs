using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("masterAudioVolume"))
        {
            PlayerPrefs.SetFloat("masterAudioVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = slider.value;
        Save();
    }


    private void Save()
    {
        PlayerPrefs.SetFloat("masterAudioVolume", slider.value);
    }

    private void Load()
    {
        slider.value = PlayerPrefs.GetFloat("masterAudioVolume");
    }

}
