using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverMenu;
    public GameObject VictoryMenu;
    bool isGameEnded = false;

    // Called when the player wins
    public void WinGame()
    {
        Debug.Log("VICTORY LOG");

        // Stop the music
        FindObjectOfType<AudioManager>().Stop("PlayTheme0");

        // Freeze the game
        Time.timeScale = 0f;

        // Set the text of the points with the current point of the player
        FindObjectOfType<VictoryMenu>().SetPoints();

        // Open the victory menu
        VictoryMenu.SetActive(true);
    }

    // Called when the player dies
    public void EndGame()
    {
        if (!isGameEnded)
        {
            isGameEnded = true;
            Debug.Log("GAME OVER LOG");

            // Play death sound
            FindObjectOfType<AudioManager>().Play("Death");

            // Stop the music
            FindObjectOfType<AudioManager>().Stop("PlayTheme0");

            // Add a delay for the player see his death

            // Freeze the game
            Time.timeScale = 0f;

            // Open the game over menu
            GameOverMenu.SetActive(true);
        }
    }
}
