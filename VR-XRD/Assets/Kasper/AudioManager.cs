using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0, 1)] public float volume = 1;
    [Range(-3, 3)] public float pitch = 1;
    public bool loop = false;
    public bool playOnAwake = false;
    public AudioSource source;

    public Sound()
    {
        volume = 1;
        pitch = 1;
        loop = false;
    }
}

public class AudioManager : MonoBehaviour
{
   
    public Sound[] Sounds;
  
    public static AudioManager instance;

    private void Awake()
    {
        instance = this;

        foreach (var sound in Sounds)
        {
            if (!sound.source)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
            }

            sound.source.clip = sound.clip;
            sound.source.playOnAwake = sound.playOnAwake;
            if (sound.playOnAwake)
            {
                sound.source.Play();
            }

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    private void Play(string clipName)
    {
        var sound = Array.Find(Sounds, s => s.name == clipName);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + clipName + " not found!");
            return;
        }

        sound.source.Play();
    }

    private void Stop(string clipName)
    {
        var sound = Array.Find(Sounds, s => s.name == clipName);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + clipName + " not found!");
            return;
        }

        sound.source.Stop();
    }
}