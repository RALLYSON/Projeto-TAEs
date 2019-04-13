using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour {

	public void OnClick(string sceneName)
    {
        ScreenFlow.Instance.LoadNextScene(sceneName);
    }
}
