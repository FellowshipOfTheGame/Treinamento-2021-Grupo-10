using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Play the fase music
        FindObjectOfType<AudioManager>().Play("PlayTheme0");

        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}