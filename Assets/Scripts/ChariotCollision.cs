using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChariotCollision : MonoBehaviour
{
    public ChariotController movement;
    private int collectableCollected = 0;

    // Detects collisions of the chariot
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Tests whether the object the chariot collides with 
        // is a destructible object
        if (collision.collider.tag == "Destructible")
        {

        }

        // Tests whether the chariot collides with 
        // the winning object
        if (collision.collider.tag == "WinCollider")
        {
            FindObjectOfType<GameManager>().WinGame();
        }

        // Tests whether the object the chariot collides with
        // is a "DeathCollider" meaning a collider that kills the player
        if (collision.collider.tag == "DeathCollider")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    // Sum 1 to the collectable collected variable
    public void AddCollectable(int value)
    {
        collectableCollected += value;
    }

    // Return the number of collectibles colleted by the player
    public int ShowCollectableCollected()
    {
        return collectableCollected;
    }
}
