using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
    public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.

    public List<TBAudioClip> sfxClips;
    public List<TBAudioClip> musicClips;

    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(string name)
    {
        TBAudioClip clip = sfxClips.Find((a) => { return a.name.Equals(name); });
        if (clip != null && clip.clip != null)
        {
            PlaySingle(clip.clip);
        }
    }

    public void PlaySingle(AudioClip clip)
    {

        efxSource.clip = clip;
        efxSource.Play();
    }

    public void PlayMusic(string name)
    {
        TBAudioClip clip = musicClips.Find((a) => { return a.name.Equals(name); });
        if (clip != null && clip.clip != null)
        {
            PlayMusic(clip.clip);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

}

[System.Serializable]
public class TBAudioClip
{
    public AudioClip clip;
    public string name;
}
