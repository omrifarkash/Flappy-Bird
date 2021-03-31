using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class soundManager
{
    public enum Sound
    {
        jump,
        die,
        score,
    }

    public static void playSound(Sound sound)
    {
        GameObject gameobject = new GameObject("Sound", typeof(AudioSource));
        AudioSource audio = gameobject.GetComponent<AudioSource>();
        audio.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach(GameAssets.soundAudioClips s in GameAssets.GetInstance().Array)
        {
            if(s.sound == sound)
            {
                return s.audioClip;
            }
        }
        return null;
    }
}
