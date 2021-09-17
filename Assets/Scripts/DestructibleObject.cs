using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public enum Type { Jar, RedJar, Box };
    public Type type;
    Animator animator;

    private bool isPassed = false;

    void Start()
    {
        // Get the Animator attached to the GameObject you are
        animator = gameObject.GetComponent<Animator>();
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Check first if this is the first collision with the player, to negate double collisions
            if (!isPassed)
            {
                isPassed = true;

                FindObjectOfType<PlayerPoints>().AddDestroyed();
                // Play animation for destruction of the object
                animator.SetTrigger("Destroy");

                // Desable the Box Collider 2D for the object fall down to the end of the world
                GetComponent<Collider2D>().enabled = false;

                // Play the sound for the destruction of the object
                switch (type)
                {
                    case Type.Jar:
                        FindObjectOfType<AudioManager>().Play("Jar");
                        break;
                    case Type.RedJar:
                        FindObjectOfType<AudioManager>().Play("RedJar");
                        break;
                    case Type.Box:
                        FindObjectOfType<AudioManager>().Play("Box");
                        break;
                }

                // Destroy the object after three seconds
                Destroy(gameObject, 3f);
            }
        }
        
    }
}
