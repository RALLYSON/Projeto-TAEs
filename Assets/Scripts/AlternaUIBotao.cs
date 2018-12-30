using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlternaUIBotao : MonoBehaviour {

    public Sprite imgAtivado, imgDesativado;

    public void Start()
    {
        try
        {
            int vol = PlayerPrefs.GetInt("volMusica");
            if(vol==1)SetImgAtivado(true);
            else SetImgAtivado(false);
        }
        catch
        {
            Debug.Log("Variavel não setada ainda.");
        }
    }

    public void SetImgAtivado(bool decisao)
    {
        if(decisao)GetComponent<Image>().sprite = imgAtivado;
        else GetComponent<Image>().sprite = imgDesativado;
    }

}
