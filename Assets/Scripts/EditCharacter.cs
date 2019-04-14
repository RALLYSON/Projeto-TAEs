using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EditCharacter : MonoBehaviour {
    public Transform bodyParts;
    public Transform characterPrefab;
    public GameObject grid;
    public GameObject slotPrefab;

   
    [Space][Space] public ItemGroup[] bodyPrefabs;
    [Space][Space] public ItemGroup[] hairPrefabs;
    [Space][Space] public ItemGroup[] clothesPrefabs;
    string lastClickedItem = " ";
    List<Transform> slots;
    string lastSlot;
    [Space] [Space] public Image[] panelTypeImgs;

    private void Start()
    {
        lastSlot = "blank";
        slots = new List<Transform>();
        UpdateSlot(SlotType.Body.ToString());
    }

    public void UpdateSlot(string slotName)
    {
        if (slotName == lastSlot)
            return;

        RemoveSlots();
        if (slotName == SlotType.Body.ToString())
            InstantiateSlots(bodyPrefabs);
        else if (slotName == SlotType.Hair.ToString())
            InstantiateSlots(hairPrefabs);

        lastSlot = slotName;
    }

    void RemoveSlots()
    {
        if (slots.Count == 0)
            return;

        foreach (Transform slot in slots)
        {
            Destroy(slot.gameObject);
        }
        slots.Clear();
    }

    void InstantiateSlots(ItemGroup[] itemPrefabs)//cria items novos no painel de items
    {
        foreach (ItemGroup itemGroup in itemPrefabs)
        {
            Transform slot = Instantiate(slotPrefab, grid.transform).transform;

            for(int i=0; i < itemGroup.items.Length; i++)
            {
                if(i!=0)
                {
                    Transform t =Instantiate(slot.GetChild(0),slot.transform);
                }
                slot.GetChild(i).GetComponent<Image>().sprite = itemGroup.items[i].sprite;
                slot.SetSiblingIndex(itemGroup.items[i].layer);
                Button button = slot.GetComponent<Button>();
                button.gameObject.SetActive(true);
                button.gameObject.GetComponent<SlotEvent>().itemGroup = itemGroup;
                button.onClick.AddListener(delegate {
                    ApplyItem(
                        itemGroup, 
                        slot.GetChild(0).GetComponent<Image>().sprite.name);
                });

            }
            slots.Add(slot);
        }
    }

    public void ApplyItem(ItemGroup itemGroup, string btName)
    {
        if (lastClickedItem.Equals(btName)) //button already clicked
            return;
        lastClickedItem = btName;

        //Deleta items antigos
        GameObject[] objsWithTag = GameObject.FindGameObjectsWithTag(itemGroup.type.ToString()+"Equipped");
        foreach (GameObject obj in objsWithTag)
            Destroy(obj);

        //Cria itens novos
        for (int i = 0; i < itemGroup.items.Length; i++)
        {
            int charPartID = itemGroup.items[i].characterPos.GetHashCode();
            Transform slot = Instantiate(panelTypeImgs[charPartID].transform, bodyParts.transform);
            slot.GetComponent<Image>().sprite = itemGroup.items[i].sprite;
            Vector3 pos = slot.GetComponent<RectTransform>().localPosition;
            pos.y = itemGroup.items[i].rectY;
            slot.GetComponent<RectTransform>().localPosition = pos;
            slot.SetSiblingIndex(itemGroup.items[i].layer); //muda a ordem na hierarquia
            slot.tag = itemGroup.type.ToString() + "Equipped";
            slot.gameObject.SetActive(true);
        }

    }

    public void SaveAndExit()
    {

        //altera e salva o prefab
        var instanceRoot = bodyParts;
        var targetPrefab = characterPrefab;
        PrefabUtility.ReplacePrefab(
                instanceRoot.gameObject,
                targetPrefab,
                ReplacePrefabOptions.ConnectToPrefab
                );


        ScreenFlow.Instance.LoadPreviousScene();

    }



}
