using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditCharacter : MonoBehaviour {
    public Transform bodyParts;

    public GameObject grid;
    public GameObject slotPrefab;
    [Space][Space] public ItemGroup[] bodyPrefabs;
    [Space][Space] public ItemGroup[] hairPrefabs;
    [Space][Space] public ItemGroup[] clothesPrefabs;



    List<Transform> slots;
    string lastSlot;
    /*[Space] [Space] public */List<GameObject> lastGroup = new List<GameObject>();
    //[Space] [Space] public List<Image> hairsParts;

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


    void InstantiateSlots(ItemGroup[] itemPrefabs)
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
                //lastGroup.Add();
                slot.SetSiblingIndex(itemGroup.items[i].layer);
                Button button = slot.GetComponent<Button>();
                button.gameObject.SetActive(true);
                button.gameObject.GetComponent<SlotEvent>().itemGroup = itemGroup;
                button.onClick.AddListener(delegate { ApplyItem(itemGroup); });

            }


            //remover o primeiro

            slots.Add(slot);
        }
    }

    public void ApplyItem(ItemGroup itemGroup)
    {



        //apply item to body

        if (lastGroup.Count > 0)
            lastGroup.Clear();


        GameObject[] objsWithTag = GameObject.FindGameObjectsWithTag(itemGroup.type.ToString()+"Equipped");//TODO:generalizar tag

        //List<GameObject> l = new List<GameObject>();

        //if(objsWithTag.Length!=0)
        //{
        //    foreach (GameObject obj in objsWithTag)
        //    {
        //        l.Add(obj);
        //        Destroy(obj);
        //    }
        //}

        foreach (GameObject obj in objsWithTag)
            Destroy(obj);


        for (int i = 0; i < itemGroup.items.Length; i++)
        {
            //Transform slot = Instantiate(slotPrefab.transform.GetChild(0), bodyParts.transform);
            int charPartID = CharSlotsDictionary.characterPosition[itemGroup.items[i].id];

            Transform slot = Instantiate(panelTypeImgs[charPartID].transform, bodyParts.transform);
            slot.GetComponent<Image>().sprite = itemGroup.items[i].sprite;
            //panelTypeImgs[charPartID].sprite = item.sprite;

            Vector3 pos = slot.GetComponent<RectTransform>().localPosition;
            pos.y = itemGroup.items[i].rectY;
            slot.GetComponent<RectTransform>().localPosition = pos;
            slot.SetSiblingIndex(itemGroup.items[i].layer);
            slot.tag = itemGroup.type.ToString() +"Equipped";
            slot.gameObject.SetActive(true);
        }

        //foreach (Item item in itemGroup.items)
        //{

        //    Instantiate(item)


        //    lastGroup.Add(item);


        //    foreach (Transform slot in slots)
        //    {
        //        Destroy(slot.gameObject);
        //    }
        //    slots.Clear();

        //}

        //if (itemGroup.items.Length > 1)
        //{

        //}

        //characterParts[charPartID].sprite = items.sprite;
        //characterParts[charPartID].transform.SetSiblingIndex(items.layer);
        //Vector3 pos = characterParts[charPartID].transform.GetComponent<RectTransform>().localPosition;
        //pos.y = items.rectY;
        //characterParts[charPartID].transform.GetComponent<RectTransform>().localPosition = pos;

        //apply item to panel
        //panelTypeImgs[charPartID].sprite = item.sprite;
    }


}
