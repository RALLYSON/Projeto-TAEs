using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BraindrawSelectionScreen : MonoBehaviour {

	public void SelectButton(string imgName)
    {
        PlayerPrefs.SetString("image",imgName);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Braindraw-Gameplay");
    }

    public void Voltar()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
