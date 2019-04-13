using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDropdown : MonoBehaviour {

    public Dropdown menuColor, menuMusic, menuFontSize;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("color_ID"))
        {
            menuColor.value = PlayerPrefs.GetInt("color_ID");
        }
        if (PlayerPrefs.HasKey("music_ID"))
        {
            menuMusic.value = PlayerPrefs.GetInt("music_ID");
        }
        if (PlayerPrefs.HasKey("fontSize_ID"))
        {
            menuFontSize.value = PlayerPrefs.GetInt("fontSize_ID");
        }


        //try
        //{
        //    menuColor.value = PlayerPrefs.GetInt("color_ID");
        //    menuMusic.value = PlayerPrefs.GetInt("music_ID");
        //    menuFontSize.value = PlayerPrefs.GetInt("fontSize_ID");
        //}
        //catch
        //{

        //}

    }
}
