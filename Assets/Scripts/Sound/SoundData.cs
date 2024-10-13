using UnityEngine;

[System.Serializable]
public class SoundData
{

    public string soundName;
    public AudioClip audioClip;
    public bool loop = false;
    [Range(0f, 1f)] public float volume = 1.0f;
    [Range(.1f, 3f)] public float pitch;
    [HideInInspector] public AudioSource source;
}