using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{

    void Start()
    {
        //PC DEBUG
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();
        //

        if (!PlayerPrefs.HasKey("firstTime"))
        {
            PlayerPrefs.SetInt("firstTime", 1);
            PlayerPrefs.Save();
            StartPlayerPrefs();
        }
        DontDestroyOnLoad(GameObject.Find("MainAudio"));


        if (!PlayerPrefs.HasKey("FirstEdit"))
        {
            ScreenFlow.Instance.AddScene("MainMenu");
            ScreenFlow.Instance.LoadNextScene("EscolhaPersona");
        }
        else
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
     
