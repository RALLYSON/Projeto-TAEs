using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AlternaUIBotao : MonoBehaviour {

    public Sprite imgAtivado, imgDesativado;
    public AudioSource audioSource;
    
    public void OnEnable()
    {
        
    }
    public void Start()
    {
        audioSource = GameObject.Find("MainAudio").GetComponent<AudioSource>();
        CheckPrefabs();

    }

    public void CheckPrefabs()
    {
        try
        {
            int vol = PlayerPrefs.GetInt("volMusica");
            if (vol == 1)
            {
                if(!audioSource.isPlaying)audioSource.Play();

            }
            else
                audioSource.Pause();

            SetImgAtivado(audioSource.isPlaying);
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

    public void PlaySoundButton()
    {
        GameObject bt = EventSystem.current.currentSelectedGameObject; //seleciona o botao que foi apertado
        bt.GetComponent<AlternaUIBotao>().SetImgAtivado(!audioSource.isPlaying);    //alterna a imagem do botao

        if (audioSource.isPlaying)
            PlayerPrefs.SetInt("volMusica", 0); //salva na configuracao da unity a decisao do volume da musica.
        else
            PlayerPrefs.SetInt("volMusica", 1);
        PlayerPrefs.Save();

        if (audioSource.isPlaying)  //se o som está tocando (ativado) ele pausa o som
            audioSource.Pause();
        else
            audioSource.Play(); // se o som não esta tocando , ele da play

        SetImgAtivado(audioSource.isPlaying);
    }

}
