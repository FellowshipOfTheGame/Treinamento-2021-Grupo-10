using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarab : MonoBehaviour
{
    // Receive the HUD with pyramids, related to the collectables
    public GameObject[] Pyramid;

    private bool isPassed = false;

    // Trigger when the player hit the colectable
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Test first if it is the first collision ever, to block double collision
        if (!isPassed)
        {
            isPassed = true;

            // Play the Scarab collision sound
            FindObjectOfType<AudioManager>().Play("ScarabCollision");

            FindObjectOfType<ChariotCollision>().AddCollectable(1);

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
}
