using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioClip bubblePop;
    private AudioSource mainSource;
    private static AudioController instanse;
  
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        mainSource = GetComponent<AudioSource>();
        //bubblePop = Resources.Load<AudioClip>("Sounds/BubblePop");
        //bubblePop = Resources.Load<AudioClip>("Sounds/BubblePop");
        mainSource.clip = bubblePop;
    }

    //void OnEnable()
    //{
    //    TestScript.OnAction += GetMessage;
    //    ButtonSound.OnAction += GetMessage;
    //}


    private void OnEnable()
    {
        MineController.OnAction += GetMessage;
    }

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instanse == null)
        {
            instanse = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void GetMessage(string message)
    {
        //if (!StaticData.isSoundEnabled)
        //    return;
        switch (message)
        {
            case "ResourceAdded":
                PlaySound(bubblePop);
                break;

        }
    }

    private void PlaySound(AudioClip clip)
    {
        mainSource.PlayOneShot(bubblePop, 1f);
    }
    //private void Click()
    //{
    //    audios[1].PlayOneShot(close, 1f);
    //}

    //public void Play()
    //{
    //    if (SettingsManager.GetMusicValue() > 0)
    //    {
    //        mainTheme.UnPause();
    //    }
    //}

    //public void Pause()
    //{
    //    mainTheme.Pause();
    //}
    //public void Stop()
    //{
    //    mainTheme.Stop();
    //}


    //public void SetMusicValue(float value)
    //{
    //    if (value == 0)
    //    {
    //        mainTheme.volume = value / 100f;
    //        mainTheme.Stop();
    //    }
    //    else
    //    {
    //        if (!mainTheme.isPlaying)
    //            mainTheme.Play();
    //        mainTheme.volume = value / 100f;
    //        //if(!mainTheme.isPlaying)
    //        //    mainTheme.Play();
    //    }
    //}


    //public void SetSoundValue(float value)
    //{
    //    if (value == 0)
    //    {
    //        audios[1].volume = 0;
    //    }
    //    else
    //    {
    //        audios[1].volume = value / 100f;
    //    }
    //}

    //public void PlayFromBegin()
    //{
    //    if (SettingsManager.GetMusicValue() > 0)
    //    {
    //        mainTheme.Stop();
    //        mainTheme.Play();
    //    }
    //}

    //public void StopMenuMusic()
    //{
    //    mainTheme.Stop();
    //}

    //public void PlayMenuMusic()
    //{
    //    mainTheme.Stop();
    //    mainTheme.clip = menu;
    //    mainTheme.Play();
    //}

    //public void PlayGameMusic()
    //{
    //    mainTheme.Stop();
    //    mainTheme.clip = game;
    //    mainTheme.Play();
    //}
}
