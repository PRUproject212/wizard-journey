using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSettingController : MonoBehaviour
{
    public Slider sliderMusic;
    public Slider sliderSound;

    void Start()
    {
        sliderMusic.value = AudioManager.Instance.currentVolumeMusic;
        sliderSound.value = AudioManager.Instance.currentVolumeSound;
    }

    // Update is called once per frame
    void Update()
    {
        //AudioManager.instance.SetVolumeMusic(sliderMusic.value);
        //AudioManager.instance.SetVolumeSound(sliderSound.value);
    }
}
