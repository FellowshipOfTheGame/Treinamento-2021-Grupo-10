using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Used for access the preload scene from any scene 
// obs: ONLY USED FOR DEVELOPMENT, NOT IMPLEMENTED FOR THE GAME
public class DevPreload : MonoBehaviour
{
    void Awake()
    {
        GameObject check = GameObject.Find("__app");

        if (check == null)
        {
            SceneManager.LoadScene("_preload");
        }
    }
}
