using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToScene : MonoBehaviour
{

    public void OnClick()
    {
        string sceneName = this.gameObject.name;

        List<SceneData> scenes = ScreenFlow.Instance.scenes;


        if (scenes[scenes.Count - 1].sceneName.Equals(sceneName))
            return;




        int index = 0;
        int length = scenes.Count;
        print(length);
        if (length == 1)
            return;
        for (int i = length - 1; i >= 0; i--)
        {
            print(length);
            print(sceneName);
            print(scenes[i].sceneName);
            if (!scenes[scenes.Count - 1].sceneName.Equals(sceneName))
            {
                print("scenelist");

                scenes.RemoveAt(scenes.Count-1);
                index++;
            }

        }

        //row back all  buttons from list
        List<GameObject> scenesBt ;

        scenesBt = ScreenFlow.Instance.scenesBt;
        for (int i = 0; i < index; i++)
        {
            print("btt");

            GameObject bt = scenesBt[scenesBt.Count - 1];
            scenesBt.Remove(bt);
            Destroy(bt);
        }


        //row back all scenes from list
        SceneManager.LoadScene(sceneName);
    }
}

