using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseDestruction : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit nose");
        transform.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit nose");
        transform.GetComponent<Rigidbody2D>().gravityScale = 1;
    }*/
}
