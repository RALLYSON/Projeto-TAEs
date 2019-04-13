using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BraindrawController : MonoBehaviour {
    public Text widthText;
    public Sprite[] templates;
    public SpriteRenderer templateRenderer;

    private void Awake()
    {
        int imgID = PlayerPrefs.GetInt("image");
        if (imgID == -1)
            templateRenderer.sprite = null;
        else
            templateRenderer.sprite = templates[imgID];
    }

    public void ChangeText(string newTxt) => widthText.text = newTxt;

    public void EnableUIObject(GameObject obj) => obj.SetActive(true);

    public void DisableUIObject(GameObject obj) => obj.SetActive(false);
   

}
