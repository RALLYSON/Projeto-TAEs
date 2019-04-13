using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColor : MonoBehaviour {


    public static CheckColor instance;

    private void Awake()
    {
        instance = this;
        ApplySavedColor();
    }

    public void ApplySavedColor()
    {
        print("ttttttttt");
        string color = "";
        try
        {
            color = PlayerPrefs.GetString("color");
        }
        catch
        {
            return;
        }
        print(color);
        if (color.Equals("Rosa")) Camera.main.backgroundColor = new Color32(255, 182, 193,255);
        else if (color.Equals("Azul")) Camera.main.backgroundColor = new Color32(153, 208, 255,255);
        else if (color.Equals("Verde")) Camera.main.backgroundColor = new Color32(143, 238, 78, 255);
        else if (color.Equals("Branco")) Camera.main.backgroundColor = new Color32(255, 255, 255, 255);
    }

}
