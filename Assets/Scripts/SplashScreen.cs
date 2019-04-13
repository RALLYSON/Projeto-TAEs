using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{

    void Start()
    {
        if (!PlayerPrefs.HasKey("firstTime"))
        {
            PlayerPrefs.SetInt("firstTime", 1);
            StartPlayerPrefs();
        }
        DontDestroyOnLoad(GameObject.Find("MainAudio"));
        ScreenFlow.Instance.LoadNextScene("MainMenu");
    }

    void StartPlayerPrefs()
    {
        //Configuração
        PlayerPrefs.SetInt("color_ID", 0);
        PlayerPrefs.SetInt("music_ID", 0);
        PlayerPrefs.SetInt("fontSize_ID", 0);

        //Volume
        PlayerPrefs.SetInt("volMusica", 1);

        //etc
        PlayerPrefs.Save();
    }
}
     
