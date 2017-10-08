using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    private AudioSource sound;
    private AudioSource[] sounds;
    public bool loop;
    public bool multipleSounds;
    public int countSounds;

    void Awake()
    {
        if (multipleSounds)
        {
            sounds = new AudioSource[countSounds];
            sounds = GetComponents<AudioSource>();
        }
        else
            sound = this.GetComponent<AudioSource>();

        if (sound != null)
        {
            if (sound.volume != BackgroundMusicContinuation.soundVolume)
                sound.volume = BackgroundMusicContinuation.soundVolume;
        }
        else
        {
            if (sounds[0].volume != BackgroundMusicContinuation.soundVolume)
            {
                setSoundsToVolume();
            }
        }

        if (loop && !multipleSounds)
        {
            sound.loop = true;
            sound.Play();
        }
    }

    public void playSound()
    {
        sound.loop = false;
        sound.Play();
    }

    public void playSound(int sound)
    {
        sounds[sound].loop = false;
        sounds[sound].Play();
    }

    private void setSoundsToVolume()
    {
        for (int i = 0; i < sounds.Length; ++i)
        {
            sounds[i].volume = BackgroundMusicContinuation.soundVolume;
        }
    }
}
