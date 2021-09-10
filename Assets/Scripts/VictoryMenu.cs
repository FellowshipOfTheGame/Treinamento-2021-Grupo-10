using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public Text timePoints;
    public Text collectablePoints;
    public Text totalPoints;

    // Set all text of the Victory Menu with the points from PlayerPoints
    public void SetPoints()
    {
        //GameObject PlayerPoints = FindObjectOfType<PlayerPoints>();

        timePoints.text = "Speed Points: " + ((int)FindObjectOfType<PlayerPoints>().TimePoints()).ToString();
        collectablePoints.text = "Collectable Points: " + ((int)FindObjectOfType<PlayerPoints>().CollectablePoints()).ToString();
        totalPoints.text = "Total Points: " + ((int)FindObjectOfType<PlayerPoints>().TotalPoints()).ToString();
    }

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
