using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerenciamento_Tela : MonoBehaviour {
    public Canvas tela_home;
    public Canvas tela_atividades;
    public Canvas tela_ajuda;
    public Canvas tela_configuracoes;
    public Canvas tela_escolha_persona;
    public Canvas tela_atividades_sala_aula;

	// Use this for initialization
	void Start () {
        tela_home.enabled = true;
        tela_atividades.enabled = false;
        tela_ajuda.enabled = false;
        tela_configuracoes.enabled = false;
        tela_escolha_persona.enabled = false;
        tela_atividades_sala_aula.enabled = false;
        Debug.Log("Start");
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Update");
    }
    public void Ativar_Tela(string nome_tela)
    {
        tela_home.enabled = false;
        tela_atividades.enabled = false;
        tela_ajuda.enabled = false;
        tela_configuracoes.enabled = false;
        tela_escolha_persona.enabled = false;
        tela_atividades_sala_aula.enabled = false;
        Debug.Log("Ativar_Tela_Atividaddes");
        switch (nome_tela)
        {
            case "home":
                tela_home.enabled = true;
                break;
            case "atividades":
                tela_atividades.enabled = true;
                break;
            case "ajuda":
                tela_ajuda.enabled = true;
                break;
            case "configuracoes":
                tela_configuracoes.enabled = true;
                break;
            case "escolha_persona":
                tela_escolha_persona.enabled = true;
                break;
            case "atividades_sala_aula":
                tela_atividades_sala_aula.enabled = true;
                break;
        }  
        Debug.Log("Ativar_Tela_Atividaddes " + nome_tela);
    }
}
