using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour
{
    void Start()
    {
        // Uses the name of the scene selected using the DevPreload Singleton
        string nextScene = FindObjectOfType<DevPreload>().scene.ToString();
        Debug.Log(nextScene);
        SceneManager.LoadScene(nextScene);
    }
}
