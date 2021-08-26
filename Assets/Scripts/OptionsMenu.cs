using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Set the volume of the game
    public void SetVolume (float volume)
    {
        // "volume" is the exposed script parameter for the Master Volume of the game
        audioMixer.SetFloat("volume", volume);
    }

    // Set the graphic quality of the game
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Set the screen in fullScreen or not in fullScreen
    public void SetScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
