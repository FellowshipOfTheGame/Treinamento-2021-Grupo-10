using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public enum Type { up, down };
    public Type type;
    public float duration = 4f;
    public ChariotController chariotController;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Search for the active Pyramid HUD
        switch(type)
        {
            case Type.up:
                Debug.Log("Collected a power up");

                // Play the powerup sound
                FindObjectOfType<AudioManager>().Play("PowerUp");

                // Set the HUD for the power up true
                animator.SetBool("isPowerUpActive", true);

                StartCoroutine (Pickup ( 1.5f, duration) );

                break;

            case Type.down:
                Debug.Log("Collected a power down");

                // Play the powerdown sound
                FindObjectOfType<AudioManager>().Play("PowerDown");

                // Set the HUD for the power down true
                animator.SetBool("isPowerDownActive", true);

                StartCoroutine (Pickup (0.75f, duration) );

                break;
        }
    }

    IEnumerator Pickup(float multiplier, float time)
    {
        // Pause the background music
        FindObjectOfType<AudioManager>().Pause("PlayTheme0");

        // Apply the power effect to the player
        chariotController.speed *= multiplier;

        // Remove the image and collision of the powerup
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(time);

        // "Remove" the power effect to the player
        chariotController.speed *= 1.0f / multiplier;

        // Unpause the background music
        FindObjectOfType<AudioManager>().Unpause("PlayTheme0");

        // Get back to the normal animation
        switch(type)
        {
            case Type.up:
                // Set the HUD for the power up false
                animator.SetBool("isPowerUpActive", false);
                break;

            case Type.down:
                // Set the HUD for the power down false
                animator.SetBool("isPowerDownActive", false);
                break;
        }

        // Destroy the collectable in the scene
        Destroy(gameObject);
    }
}
