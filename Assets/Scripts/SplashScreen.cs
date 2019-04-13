using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    void Start()
    {
        DontDestroyOnLoad(GameObject.Find("MainAudio"));
        ScreenFlow.Instance.LoadNextScene("MainMenu");
    }
	
    
}
