using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFlow : MonoBehaviour
{
    public static ScreenFlow Instance;
    private int lastID = 0;

    public class SceneData
    {
        public string name;
        public int id;

        public SceneData(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }

    public List<SceneData> scenes = new List<SceneData>();

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //// called second
    //void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    Debug.Log("OnSceneLoaded: " + scene.name);
    //    Debug.Log(mode);
    //}

    public void Awake()
    {
        if (!Instance)
            Instance = this;
        else
            Debug.LogError("Há mais de 1 instancia de ScreenFlow");

        DontDestroyOnLoad(this);
    }

    public void LoadNextScene(string sceneName)
    {
        lastID++;
        scenes.Add(
                new SceneData(sceneName, lastID)
            );
        print(lastID);
        SceneManager.LoadScene(sceneName);
    }

    public void LoadPreviousScene()
    {
        lastID--;
        scenes.RemoveAt(scenes.Count-1);
        SceneManager.LoadScene(scenes[scenes.Count - 1].name);
    }

    public void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void LoadHomeScene() => SceneManager.LoadScene("MainMenu");

	
}
