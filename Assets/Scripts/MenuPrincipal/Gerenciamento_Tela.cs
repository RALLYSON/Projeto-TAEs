using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerenciamento_Tela : MonoBehaviour {
    public GameObject tela_home;
    public GameObject tela_atividades;
    public GameObject tela_ajuda;
    public GameObject tela_configuracoes;
    public GameObject tela_escolha_persona;
    public GameObject tela_atividades_sala_aula;
    public GameObject tela_atividades_braindraw;

    // Use this for initialization
    void Start () {
        tela_home.SetActive(true);
        tela_atividades.SetActive(false);
        tela_ajuda.SetActive(false);
        tela_configuracoes.SetActive(false);
        tela_escolha_persona.SetActive(false);
        tela_atividades_sala_aula.SetActive(false);
        tela_atividades_braindraw.SetActive(false);

    Debug.Log("Start");
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Update");
    }

    

    public void Ativar_Tela(string nome_tela)
    {
        print(nome_tela);
        tela_home.SetActive(false);
        tela_atividades.SetActive(false);
        tela_ajuda.SetActive(false);
        tela_configuracoes.SetActive(false);
        tela_escolha_persona.SetActive(false);

        Debug.Log("Ativar_Tela_Atividaddes");
        switch (nome_tela)
        {
            case "home":
                tela_home.SetActive(true);
                break;
            case "atividades":
                tela_atividades.SetActive(true);
                break;
            case "ajuda":
                tela_ajuda.SetActive(true);
                break;
            case "configuracoes":
                tela_configuracoes.SetActive(true);
                break;
            case "escolha_persona":
                tela_escolha_persona.SetActive(true);
                break;
            case "atividades_sala_aula":
                //tela_atividades_sala_aula.enabled = true;
                SceneManager.LoadScene("SalaDeAula");
                break;
            case "atividades_braindraw":
                //tela_atividades_sala_aula.enabled = true;
                SceneManager.LoadScene("Braindraw");
                break;
        }  
        Debug.Log("Ativar_Tela_Atividaddes " + nome_tela);
    }
}
