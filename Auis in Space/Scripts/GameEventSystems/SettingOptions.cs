using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SettingOptions : MonoBehaviour {

    public AudioMixer audioMixer;

	public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }

    public void SetFullScreen(bool isScreenOption)
    {
        Screen.fullScreen = isScreenOption;
    }




/*public void SetFullScreen(int isScreenOption)
{
    if(isScreenOption == 0)
    {
        Screen.fullScreen = false;
    }else
    {
        Screen.fullScreen = true;

    }
}*/
}
