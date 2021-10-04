using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start when the game is iniciated
    private void Start()
    {
        // Plays the song of the main menu, using the AudioManager object
        FindObjectOfType<AudioManager>().Play("MainMenuTheme");
    }

    // Produce the click sound
    public void ClickSound()
    {
        // Play the click sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    // Change the current scene to the playable game scene
    public void PlayGame ()
    {
        // Stop the Main Menu Theme Sound
        FindObjectOfType<AudioManager>().Stop("MainMenuTheme");        

        // Play the click sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");

        // Loads the next level in the queue of scenes
        // Obs: the default scene for the Menu is 1, and for the playable game is 2
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Close the game
    public void QuitGame ()
    {
        Debug.Log("QUIT FUNCTION ENTRY");

        // Play the click sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");

        // Quit the game
        Application.Quit();
    }

}
