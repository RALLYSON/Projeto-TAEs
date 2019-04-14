using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMusic : MonoBehaviour
{
    public static CheckMusic instance;

    private void Awake()
    {
        instance = this;
        ApplySavedMusic();
    }

    public void ApplySavedMusic()
    {
        int musicID = 0;
        try
        {
            musicID = PlayerPrefs.GetInt("music_ID");
        }
        catch
        {
            return;
        }
        GetComponent<AudioSource>().clip = Resources.Load("Audio/" + "Musica"+musicID.ToString()) as AudioClip;

        if (PlayerPrefs.GetInt("volMusica") == 1)
            GetComponent<AudioSource>().Play();
        else
            GetComponent<AudioSource>().Pause();
       
    }

}
