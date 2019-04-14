using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeScreenshot : MonoBehaviour {
    public Canvas canvas;

    public void OnClick()
    {
        StartCoroutine(CaptureScreen());
    }

    public IEnumerator CaptureScreen()  // Faz a captura de tela
    {
        canvas.enabled = false;
        yield return new WaitForEndOfFrame();
        //ScreenCapture.CaptureScreenshot(Application.persistentDataPath + "/" + "MinhaSala " + id + ".png");
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // Save the screenshot to Gallery/Photos
        string sceneName = SceneManager.GetActiveScene().name;
        string name = string.Format("{0}_" + sceneName + "{1}_{2}.png", Application.productName, "{0}", System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, Application.productName + " Captures", name));
        canvas.enabled = true;
    }
}
