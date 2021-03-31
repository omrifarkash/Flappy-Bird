﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets instance;

    public static GameAssets GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    public Transform prePipe;
    public soundAudioClips[] Array;

    [Serializable]
    public class soundAudioClips
    {
        public soundManager.Sound sound;
        public AudioClip audioClip;
    }
    
}
