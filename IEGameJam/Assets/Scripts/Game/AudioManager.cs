using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    //when using the singleton type AudioManager.instance.Play(Name of the sound array that you typed in the inpsector)
    public static AudioManager instance;

    // will destroy the object when you load in a new scene so it does not continue
    public bool destroyOnNextLoad;


    private void Awake()
    {
        //if(destroyOnNextLoad == true)
        //    DontDestroyOnLoad(gameObject);

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        } 
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }
    
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {                        
            Debug.LogError("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
    public void Play(string name, bool putInArray)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
