using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Audio_Gerenciamento : MonoBehaviour {
    [SerializeField]
    bool tocandoSom;

    void Start () {
        tocandoSom = true;
        if (PlayerPrefs.HasKey("volMusica"))
        {
            int vol = PlayerPrefs.GetInt("volMusica");
            if (vol == 1) tocandoSom = true;
            else tocandoSom = false;
        }
        

	}

	public void PlaySoundButton()
    {
        GameObject bt = EventSystem.current.currentSelectedGameObject; //seleciona o botao que foi apertado
        bt.GetComponent<AlternaUIBotao>().SetImgAtivado(!tocandoSom);    //alterna a imagem do botao

        if (tocandoSom) PlayerPrefs.SetInt("volMusica", 0); //salva na configuracao da unity a decisao do volume da musica.
        else PlayerPrefs.SetInt("volMusica", 1);
        PlayerPrefs.Save();

        if (tocandoSom)  //se o som está tocando (ativado) ele pausa o som
        {
            GetComponent<AudioSource>().Pause();
        }
        else
        {
            GetComponent<AudioSource>().Play(); // se o som não esta tocando , ele da play
        }
        tocandoSom = !tocandoSom;
    }

  
   
}
