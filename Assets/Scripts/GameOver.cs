using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Load the Play scene
    public void PlayAgain()
    {
        // Play the click sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");

        Time.timeScale = 1f;
        SceneManager.LoadScene("Play");
    }

    // Load the Main Menu scene
    public void LoadMenu()
    {
        // Play the click sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");

        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    // Quit the game
    public void QuitGame()
    {
        // Play the click sound
        FindObjectOfType<AudioManager>().Play("ButtonClick");

        Debug.Log("Quit the game");
        Application.Quit();
    }
}
