using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverMenu;
    bool isGameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        if (!isGameEnded)
        {
            isGameEnded = true;
            Debug.Log("GAME OVER LOG");

            // Add a delay for the player see his death

            // Freeze the game
            Time.timeScale = 0f;

            // Open the game over menu
            GameOverMenu.SetActive(true);
        }
    }
}
