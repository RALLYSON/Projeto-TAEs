using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BraindrawSelectionScreen : MonoBehaviour {

	public void SelectButton(string imgName)
    {
        PlayerPrefs.SetInt("image",DrawTemplates.templatesDict[imgName]);
        PlayerPrefs.Save();
        ScreenFlow.Instance.LoadNextScene("Braindraw-Gameplay");
    }

    public void Voltar()
    {
        ScreenFlow.Instance.LoadPreviousScene();
    }
}
