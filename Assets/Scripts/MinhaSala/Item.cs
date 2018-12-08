using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    public int layer;

    void OnMouseDown()  // mouse está clicando no objeto selecionado
    {
        GetComponent<SpriteRenderer>().sortingOrder = layer;

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()  //usuario está arrastando o objeto, escolhendo em que parte da cena ele quer inserir 
    {
        if (GameObject.Find("FundoDeSelecao")) GameObject.Find("FundoDeSelecao").SetActive(false);  //remve fundo cinza de seleção

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;  //movimenta o objeto
        transform.position = curPosition;
    }



}
