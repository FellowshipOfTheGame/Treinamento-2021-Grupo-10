using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarab : MonoBehaviour
{
    // Receive the HUD with pyramids, related to the collectables
    public GameObject[] Pyramid; 

    // Trigger when the player hit the colectable
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collected a scarab");

        // Play the Scarab collision sound
        FindObjectOfType<AudioManager>().Play("ScarabCollision");

        // Search for the active Pyramid HUD
        for (int i = 0; i < Pyramid.Length - 1; i++)
        {
            // If is active in the HUD, sets it false
            // and put the next pyramid active
            if (Pyramid[i].activeSelf)
            {
                Pyramid[i].SetActive(false);
                Pyramid[i + 1].SetActive(true);
                
                break;
            }
        }

        // Destroy the collectable for the scene
        Destroy(gameObject);
    }
}
