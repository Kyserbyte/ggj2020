using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;
    public AudioSource musicSource;
    public AudioSource tmpSource;

    public static SoundManager instance = null;
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

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

    public void PlaySingle(string name, float vol = 1f)
    {
        TBAudioClip clip = sfxClips.Find((a) => { return a.name.Equals(name); });
        if (clip != null && clip.clip != null)
        {
            PlaySingle(clip.clip, vol);
        }
    }

    public void PlaySingle(AudioClip clip, float vol = 1f)
    {
        if (efxSource.clip != clip || (efxSource.clip == clip && !efxSource.isPlaying))
        {
            efxSource.volume = vol;
            efxSource.clip = clip;
            efxSource.Play();
        }
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

    public void PlayTmp(string name, float vol = 1f)
    {
        TBAudioClip clip = sfxClips.Find((a) => { return a.name.Equals(name); });
        if (clip != null && clip.clip != null)
        {
            PlayTmp(clip.clip, vol);
        }
    }

    public void PlayTmp(AudioClip clip, float vol = 1f)
    {
        if (tmpSource.clip != clip || (tmpSource.clip == clip && !tmpSource.isPlaying))
        {
            tmpSource.volume = vol;
            tmpSource.clip = clip;
            tmpSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void StopSfx()
    {
        efxSource.Stop();
    }

}

[System.Serializable]
public class TBAudioClip
{
    public AudioClip clip;
    public string name;
}
