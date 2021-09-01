using UnityEngine.Audio;
using System;
using UnityEngine;

// How to use:
// Inside some script of an object you desire to play a sound listed on the AudioManager
// you can simply type: 
// ***************** 'FindObjectOfType<AudioManager>().Play("Name of the sound");' ******************
// passing the name of the sound to play it.

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // 'instance' references to itself
    public static AudioManager instance;

    // Awake is called before the Start method
    void Awake()
    {
        /*
        // checks if there is already one AudioManager instance (NOT USED FOR THIS GAME)
        // IF NOT, keep this object
        
        if (instance == null)
            instance = this;
        // IF YES, destroy this object
        else
        {
            Destroy(gameObject);
            return;
        }       

        // Make the AudioManager sound continue even when the scene is switched (NOT USED FOR THIS GAME)
        DontDestroyOnLoad(gameObject);
        */

        // For each sound described on the AudioManager, set a AudioSource object
        // with the defined configurations
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            s.source.outputAudioMixerGroup = s.output;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    // Play the sound with the 'name' passed by parameter
    public void Play (string name)
    {
        // search in the sound array the sound with de given name
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // Check it the given 'name' exists
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found!");
            return;
        }         

        
        // Play the sound found
        s.source.Play();
    }
}
