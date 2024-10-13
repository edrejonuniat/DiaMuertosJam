using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField]private SoundData[] musicSounds, sfxSounds;
    [SerializeField] private AudioSource musicSource, sfxSource;

    public static AudioManager instance;

    public static AudioManager Instance
    {
        get { return instance; }
    }


    private void Awake()
    {
        if (Instance == null)
        {
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(this);
        }
        foreach (SoundData sound in sfxSounds)
        {
            GameObject soundObject = new GameObject(sound.soundName);
            soundObject.transform.SetParent(transform);
            AudioSource audioSource = soundObject.AddComponent<AudioSource>();
            audioSource.clip = sound.audioClip;
            audioSource.volume = sound.volume;
            audioSource.pitch = sound.pitch;
            audioSource.loop = sound.loop;
        }
        foreach (SoundData s in musicSounds) {
              s.source = gameObject.AddComponent<AudioSource>();
              s.source.clip = s.audioClip;

              s.source.volume = s.volume;
              s.source.pitch = s.pitch;
              s.source.loop = s.loop;
          }
    }
     private void Start()
      {
          musicSource.volume = 3f;
          sfxSource.volume = 3f;
          PlayMusic("Mu_Niv1");
      }


      public void PlayMusic(string name)
      {
          SoundData s = Array.Find(musicSounds, x => x.soundName == name);

          if (s == null)
          {
              Debug.LogWarning("Sound not found");
          }

          else
          {
              musicSource.clip = s.audioClip;
              musicSource.Play();
          }
      }

      public void PlaySFX(string name)
      {
          SoundData s = Array.Find(sfxSounds, x => x.soundName == name);

          if (s == null)
          {
              Debug.LogWarning("Sound not found");
          }

          else
          {
              sfxSource.PlayOneShot(s.audioClip);
          }
      }

      public void ToggleMusic()
      {
          musicSource.mute = !musicSource.mute;
      }

      public void ToggleSFX()
      {
          sfxSource.mute = !sfxSource.mute;
      }

      public void MusicVolume(float volume)
      {
          musicSource.volume = volume;
      }

      public void SFXVolume(float volume)
      {
          sfxSource.volume = volume;
      }

    // public void Play(string name)
    // {
    //     SoundData sound = Array.Find(sounds, s => s.name == name);
    //     if (sound == null)
    //     {
    //         Debug.LogWarning("Sound: " + name + " not found!");
    //         return;
    //     }
    //     Transform soundTransform = transform.Find(name);
    //     if (soundTransform != null)
    //     {
    //         AudioSource audioSource = soundTransform.GetComponent<AudioSource>();
    //         audioSource.Play();
    //     }
    // }

    // public void Stop(string name)
    // {
    //     SoundData sound = Array.Find(sounds, s => s.name == name);
    //     if (sound == null)
    //     {
    //         Debug.LogWarning("Sound: " + name + " not found!");
    //         return;
    //     }
    //     Transform soundTransform = transform.Find(name);
    //     if (soundTransform != null)
    //     {
    //         AudioSource audioSource = soundTransform.GetComponent<AudioSource>();
    //         audioSource.Stop();
    //     }
    // }
}