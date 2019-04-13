using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerenciamento_Tela : MonoBehaviour {

    public void Ativar_Tela(string nome_tela)
    {
        switch (nome_tela)
        {
            case "atividades":
                ScreenFlow.Instance.LoadNextScene("Atividades");
                break;
            case "ajuda":
                ScreenFlow.Instance.LoadNextScene("Ajuda");
                break;
            case "configuracoes":
                ScreenFlow.Instance.LoadNextScene("Configuracoes");
                break;
            case "escolha_persona":
                ScreenFlow.Instance.LoadNextScene("Escolha-Persona");
                break;
            case "atividades_sala_aula":
                ScreenFlow.Instance.LoadNextScene("SalaDeAula");
                break;
            case "atividades_braindraw":
                ScreenFlow.Instance.LoadNextScene("Braindraw");
                break;
        }  
    }
}
