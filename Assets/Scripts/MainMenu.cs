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

    // Change the current scene to the playable game scene
    public void PlayGame ()
    {
        // Loads the next level in the queue of scenes
        // Obs: the default scene for the Menu is 0, and for the playable game is 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Close the game
    public void QuitGame ()
    {
        Debug.Log("QUIT FUNCTION ENTRY");
        Application.Quit();
    }

}
