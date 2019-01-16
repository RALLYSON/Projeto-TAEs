using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigEditaveis : MonoBehaviour {


    public void SetColor(Dropdown dropDown)
    {
        string option = dropDown.options[dropDown.value].text;
        PlayerPrefs.SetString("color", option);
        print(option);
        print(dropDown.value);
        print("AAAAAAAAAAAA");

        PlayerPrefs.SetInt("color_ID", dropDown.value);
        PlayerPrefs.Save();
        CheckColor.instance.ApplySavedColor();
    }

    public void SetMusic(Dropdown dropDown)
    {
        string option = dropDown.options[dropDown.value].text;
        PlayerPrefs.SetString("music", option);
        PlayerPrefs.SetInt("music_ID", dropDown.value);
        PlayerPrefs.Save();
    }

    public void SetFontSize(Dropdown dropDown)
    {
        string option = dropDown.options[dropDown.value].text;
        PlayerPrefs.SetString("fontSize", option);
        PlayerPrefs.SetInt("fontSize_ID", dropDown.value);
        PlayerPrefs.Save();
    }
}
