using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    // Play when the game starts
    void Start ()
    {
        // Keep the resolutions available for the current user machine
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> resolutionList = new List<string>();


        int currentResolutionIndex = 0;

        // Transforms the resolution list in a list of strings 
        // for the resolutionDropdown formatation
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            resolutionList.Add(option);

            // Search for the index of the current screen resolution and
            // keeps his value in the variable 'currentResolutionIndex'
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Add the user resolution list in the resolution dropdown in the MainMenu
        resolutionDropdown.AddOptions(resolutionList);

        // Add the current resolution in the dropdown default value
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Set the resolution of the game
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = Screen.resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

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
