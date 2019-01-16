﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    private AudioSource source;
    public void SetSource (AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }
}
public class Audio_Gerenciamento : MonoBehaviour {
    [SerializeField]
    Sound[] sounds;
    bool tocandoSom;
    AudioSource[] audioSources; //vetor de audiosources

    void Start () {
        tocandoSom = true;
        if (PlayerPrefs.HasKey("volMusica"))
        {
            int vol = PlayerPrefs.GetInt("volMusica");
            if (vol == 1) tocandoSom = true;
            else tocandoSom = false;
        }
        

        audioSources = new AudioSource[sounds.Length];
		for(int i=0; i < sounds.Length; i++)
        {
            GameObject obj = new GameObject("Sound_" + i + "_" + sounds[i].clip.name);  //lê o nome original do audio
            obj.transform.SetParent(this.transform);
            sounds[i].SetSource(obj.AddComponent<AudioSource>());
            audioSources[i] = obj.GetComponent<AudioSource>();
            obj.GetComponent<AudioSource>().loop = true;
            if(tocandoSom)obj.GetComponent<AudioSource>().Play();
        }
	}


	public void PlaySoundButton( string _nome)
    {
        GameObject bt = EventSystem.current.currentSelectedGameObject; //seleciona o botao que foi apertado
        bt.GetComponent<AlternaUIBotao>().SetImgAtivado(!tocandoSom);    //alterna a imagem do botao


        if (tocandoSom) PlayerPrefs.SetInt("volMusica", 0); //salva na configuracao da unity a decisao do volume da musica.
        else PlayerPrefs.SetInt("volMusica", 1);
        PlayerPrefs.Save();

        if (tocandoSom)  //se o som está tocando (ativado) ele pausa o som
        {
            PauseSom(_nome);
            return;
        }
        TocarSom(_nome); // se o som não esta tocando , ele da play
        
    }

    public void TocarSom(string _nome)
    {
        tocandoSom = true;
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].clip.name == _nome)
            {
                audioSources[i].Play();
                return;
            }
        }
    }
    public void PauseSom(string _nome)
    {
        tocandoSom = false;
        for (int i = 0; i < audioSources.Length; i++)
        {
            print(audioSources[i].clip.name);
            if (audioSources[i].clip.name == _nome)
            {
                audioSources[i].Pause();
                return;
            }
        }
    }
   
}