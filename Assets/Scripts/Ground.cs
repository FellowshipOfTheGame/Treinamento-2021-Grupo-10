using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Start the background song of the game
        FindObjectOfType<AudioManager>().Play("PlayTheme0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
