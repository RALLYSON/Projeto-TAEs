using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
public class MinhaSalaController : MonoBehaviour {
 
    public GameObject fundoSelecao;
    public GameObject menuSelecao;
    public GameObject posicioneMenu;
    public GameObject ultimoSelecionado;

	public void Pressed()   // quando clica em escolher um item
	{
		Transform obj = EventSystem.current.currentSelectedGameObject.transform;	//Objeto clicado
		string objName = obj.GetChild(0).GetComponent<Image>().sprite.name;    //recebo da figura
        GameObject newObj = new GameObject();   //crio um objeto vazio
        newObj.AddComponent<Item>();
        Debug.Log(objName);
        newObj.AddComponent<SpriteRenderer>();
        newObj.transform.localScale = new Vector3(.5F,.5F,.5F);
        string nome = Resources.Load<Sprite>("Figuras_SalaAula/"+ objName).name;  //carrega a imagem da pasta figuras-salaaula/nomedoObjeto
        string[] tokens = nome.Split('-');
        if (tokens.Length > 1) newObj.GetComponent<Item>().layer = int.Parse(tokens[1]);
        else newObj.GetComponent<Item>().layer = 2;
        newObj.GetComponent<SpriteRenderer>().sortingOrder = 11;     //camada 2 
        newObj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Figuras_SalaAula/" + objName);
        newObj.AddComponent<BoxCollider2D>();
        newObj.AddComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("ItemAnimator");
        fundoSelecao.SetActive(true);
        posicioneMenu.SetActive(true);
        menuSelecao.SetActive(false);
        ultimoSelecionado = newObj;
       

    }

    public void CancelarBt()    //cancela a escolha do item
    {
        fundoSelecao.SetActive(false);
        posicioneMenu.SetActive(false);
        menuSelecao.SetActive(true);
        Destroy(ultimoSelecionado);
        ultimoSelecionado = null;

    }

    public void VoltarBt()  //volta para o menu principal
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void ReiniciarBt()   //reinica a cena
    {
        SceneManager.LoadScene("SalaDeAula");
    }

    public void OkBt()  //Botao de confirmar selecao do item
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
        StartCoroutine(CaptureScreen());
    }

    public IEnumerator CaptureScreen()  // Faz a captura de tela
    {
        GameObject.Find("Canvas_Tela_SalaDeAula").GetComponent<Canvas>().enabled = false;
        yield return new WaitForEndOfFrame();
        //ScreenCapture.CaptureScreenshot(Application.persistentDataPath + "/" + "MinhaSala " + id + ".png");
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // Save the screenshot to Gallery/Photos
        string name = string.Format("{0}_MinhaSala{1}_{2}.png", Application.productName, "{0}", System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, Application.productName + " Captures", name));

        GameObject.Find("Canvas_Tela_SalaDeAula").GetComponent<Canvas>().enabled = true;
    }




}
