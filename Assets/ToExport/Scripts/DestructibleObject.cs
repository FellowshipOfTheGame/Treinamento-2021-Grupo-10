using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        // Get the Animator attached to the GameObject you are
        animator = gameObject.GetComponent<Animator>();
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Destroy");
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
