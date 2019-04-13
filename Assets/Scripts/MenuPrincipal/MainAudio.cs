//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class MainAudio : MonoBehaviour
//{

//    public static MainAudio Instance;
//    public AudioSource audioSource;

//    private void Awake()
//    {
//        if (!Instance)
//            Instance = this;
//        else
//            Debug.LogError("Há mais de 1 MainAudio.");


//    }

//    public void PlaySoundButton()
//    {
//        GameObject bt = EventSystem.current.currentSelectedGameObject; //seleciona o botao que foi apertado
//        bt.GetComponent<AlternaUIBotao>().SetImgAtivado(!audioSource.isPlaying);    //alterna a imagem do botao

//        if (audioSource.isPlaying)
//            PlayerPrefs.SetInt("volMusica", 0); //salva na configuracao da unity a decisao do volume da musica.
//        else
//            PlayerPrefs.SetInt("volMusica", 1);
//        PlayerPrefs.Save();

//        if (audioSource.isPlaying)  //se o som está tocando (ativado) ele pausa o som
//            audioSource.Pause();
//        else
//            GetComponent<AudioSource>().Play(); // se o som não esta tocando , ele da play
//    }

//}
