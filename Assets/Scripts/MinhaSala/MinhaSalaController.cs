using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
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

    public void CancelarBt()
    {
        fundoSelecao.SetActive(false);
        posicioneMenu.SetActive(false);
        menuSelecao.SetActive(true);
        Destroy(ultimoSelecionado);
        ultimoSelecionado = null;

    }

    public void VoltarBt()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void ReiniciarBt()
    {
        SceneManager.LoadScene("SalaDeAula");
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
    //private IEnumerator TakeScreenshotAndSave()
    //{
    //    //takingScreenshot = true;
    //    //yield return new WaitForEndOfFrame();

        
    //    //takingScreenshot = false;
    //}
    public void ScreenshotBt()
    {
        //int id = AtualizaPlayerPrefs();
        StartCoroutine(CaptureScreen());

    }

    //int AtualizaPlayerPrefs()
    //{
    //    int id = 0;
    //    if (PlayerPrefs.HasKey("screenshotID")) // busca o valor da variavel screenshotID nas preferencias do usuario (como se fosse um mini ''banco de dados do jogo'')
    //    {
    //        id = PlayerPrefs.GetInt("screenshotID");
    //        id++;
    //    }
    //    PlayerPrefs.SetInt("screenshotID", id); //altera a variavel nas preferencias do usuario
    //    PlayerPrefs.Save(); //salva as alterações do ''mini banco de dados  do jogo''
    //    return id;
    //}

    public IEnumerator CaptureScreen()
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
