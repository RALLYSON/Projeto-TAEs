using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToScene : MonoBehaviour
{

    public void OnClick(string sceneName)
    {
        ScreenFlow.Instance.LoadNextScene(sceneName);
    }
}

