using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public enum Type { up, down };
    public Type type;
    public ChariotController chariotController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Play the Scarab collision sound
        FindObjectOfType<AudioManager>().Play("ScarabCollision");

        // Search for the active Pyramid HUD
        switch(type)
        {
            case Type.up:
                Debug.Log("Collected a power up");
                StartCoroutine(ChangeCharacterSpeed(1.5f, 1f));
                break;
            case Type.down:
                Debug.Log("Collected a power down");
                StartCoroutine(ChangeCharacterSpeed(0.75f, 1f));
                break;
        }

        // Destroy the collectable for the scene
        Destroy(gameObject);
    }

    IEnumerator ChangeCharacterSpeed(float multiplier, float time)
    {
        chariotController.speed *= multiplier;
        yield return new WaitForSeconds(time);
        chariotController.speed *= 1.0f / multiplier;
    }
}
