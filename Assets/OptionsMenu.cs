using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Set the volume of the game
    public void SetVolume(float volume)
    {
        // "volume" is the exposed script parameter for the Master Volume of the game
        audioMixer.SetFloat("volume", volume);
    }
}
