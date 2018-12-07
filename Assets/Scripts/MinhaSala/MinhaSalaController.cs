using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MinhaSalaController : MonoBehaviour {
    // [HideInInspector] 
    // public bool segurandoItem;
    public GameObject fundoSelecao;
    public GameObject menuSelecao;
    public GameObject posicioneMenu;
    public GameObject ultimoSelecionado;

	public void Pressed()
	{
		Transform obj = EventSystem.current.currentSelectedGameObject.transform;	//Objeto clicado
		string objName = obj.GetChild(0).GetComponent<Image>().sprite.name;    //recebo da figura
        GameObject newObj = new GameObject();   //crio um objeto vazio
        newObj.AddComponent<Item>();
        Debug.Log(objName);
        newObj.AddComponent<SpriteRenderer>();
        newObj.transform.localScale = new Vector3(.5F,.5F,.5F);
        string nome = Resources.Load<Sprite>("Figuras_SalaAula/"+ objName).name;  //carrega a imagem da pasta figuras-salaaula/nomedoObjeto
        newObj.GetComponent<SpriteRenderer>().sortingOrder = 2;     //camada 2 
        newObj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Figuras_SalaAula/" + objName);
        newObj.AddComponent<BoxCollider2D>();
        newObj.AddComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("ItemAnimator");
        fundoSelecao.SetActive(true);
        posicioneMenu.SetActive(true);
        menuSelecao.SetActive(false);
        ultimoSelecionado = newObj;
        //string[] tokens = nome.Split('-');
        //newObj.GetComponent<SpriteRenderer>().sortingOrder = int.Parse(tokens[1]);

    }

    public void CancelarBt()
    {
        fundoSelecao.SetActive(false);
        posicioneMenu.SetActive(false);
        menuSelecao.SetActive(true);
        Destroy(ultimoSelecionado);
        ultimoSelecionado = null;

    }

    public void OkBt()
    {
        ultimoSelecionado.GetComponent<Animator>().enabled = false;
        ultimoSelecionado.transform.localScale = new Vector3(.5F, .5F, .5F);
        ultimoSelecionado.GetComponent<Collider2D>().enabled = false;
        ultimoSelecionado = null;
        fundoSelecao.SetActive(false);
        posicioneMenu.SetActive(false);
        menuSelecao.SetActive(true);
    }

    public void ScreenshotBt()
    {
        int id = 0;
        if (PlayerPrefs.HasKey("screenshotID"))
        {
            id = PlayerPrefs.GetInt("screenshotID");
            id++;
        }
        ScreenCapture.CaptureScreenshot("C:/Users/ivostinghen/Desktop/MinhaSala " + id + ".png");
        PlayerPrefs.SetInt("screenshotID", id);
        PlayerPrefs.Save();
    }




}
