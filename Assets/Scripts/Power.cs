using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public enum Type { up, down };
    public Type type;
    public ChariotController chariotController;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Search for the active Pyramid HUD
        switch(type)
        {
            case Type.up:
                Debug.Log("Collected a power up");

                // Pause the background music
                FindObjectOfType<AudioManager>().Pause("PlayTheme0");

                // Play the powerup sound
                FindObjectOfType<AudioManager>().Play("PowerUp");

                // Set the HUD for the power up true
                animator.SetBool("isPowerUpActive", true);

                StartCoroutine(ChangeCharacterSpeed(1.5f, 1f));

                // Set the HUD for the power up false
                animator.SetBool("isPowerUpActive", false);

                // Unpause the background music
                FindObjectOfType<AudioManager>().Unpause("PlayTheme0");

                break;
            case Type.down:
                Debug.Log("Collected a power down");

                // Pause the background music
                FindObjectOfType<AudioManager>().Pause("PlayTheme0");

                // Play the powerdown sound
                FindObjectOfType<AudioManager>().Play("PowerDown");

                // Set the HUD for the power down true
                animator.SetBool("isPowerDownActive", true);

                StartCoroutine(ChangeCharacterSpeed(0.75f, 1f));

                // Set the HUD for the power down false
                animator.SetBool("isPowerDownActive", false);

                // Unpause the background music
                FindObjectOfType<AudioManager>().Unpause("PlayTheme0");

                break;
        }

        // Destroy the collectable for the scene
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }

    IEnumerator ChangeCharacterSpeed(float multiplier, float time)
    {
        chariotController.speed *= multiplier;
        yield return new WaitForSeconds(time);

        chariotController.speed *= 1.0f / multiplier;
    }
}
