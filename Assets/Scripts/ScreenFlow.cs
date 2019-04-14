using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenFlow : MonoBehaviour
{
    public static ScreenFlow Instance;
    private int lastID = 0;
    public GameObject sceneBtPrefab;
    public Transform panelParent;

    

    public List<SceneData> scenes = new List<SceneData>();
    public List<GameObject> scenesBt = new List<GameObject>();

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
        GameObject bt = Instantiate(sceneBtPrefab, panelParent);
        bt.transform.GetChild(0).GetComponent<Text>().text = sceneName;
        bt.gameObject.name = sceneName;
        scenesBt.Add(bt);
        print(scenes[scenes.Count - 1].sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void LoadPreviousScene()
    {
        lastID--;
        scenes.RemoveAt(scenes.Count-1);
        GameObject bt = scenesBt[scenesBt.Count - 1];
        scenesBt.Remove(bt);
        Destroy(bt);
        SceneManager.LoadScene(scenes[scenes.Count - 1].sceneName);
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 7)
        {
            panelParent.gameObject.SetActive(false);
        }
        else
        {
            panelParent.gameObject.SetActive(true);

        }
    }

    public void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void LoadHomeScene() => SceneManager.LoadScene("MainMenu");

	
}
