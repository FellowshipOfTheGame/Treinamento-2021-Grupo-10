using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseDestruction : MonoBehaviour
{
    private bool isPassed = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isPassed)
        {
            isPassed = true;
            FindObjectOfType<PlayerPoints>().AddDestroyed();
            Debug.Log("Hit nose");
            transform.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
