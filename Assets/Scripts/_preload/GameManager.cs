using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject GameOverMenu;
    public GameObject VictoryMenu;
    public GameObject HUD;
    bool isGameEnded = false;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Called when the player wins
    public void WinGame()
    {
        //HUD.SetActive(false);
        Debug.Log("VICTORY LOG");

        // Stop the music
        audioManager.Stop("PlayTheme0");

        // Play victory sound
        audioManager.Play("Victory");

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
            //HUD.SetActive(false);
            isGameEnded = true;
            Debug.Log("GAME OVER LOG");

            // Play death sound
            audioManager.Play("Death");

            // Stop the music
            audioManager.Stop("PlayTheme0");

            // Add a delay for the player see his death

            // Freeze the game
            Time.timeScale = 0f;

            // Open the game over menu
            GameOverMenu.SetActive(true);
        }
    }
}
