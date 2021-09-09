using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChariotCollision : MonoBehaviour
{
    public ChariotController movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detects collisions of the chariot
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Tests whether the object the chariot collides with 
        // is a destructible object
        if (collision.collider.tag == "Destructible")
        {

        }
        // Tests whether the object the chariot collides with
        // is a "DeathCollider" meaning a collider that kills the player
        if (collision.collider.tag == "DeathCollider")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
