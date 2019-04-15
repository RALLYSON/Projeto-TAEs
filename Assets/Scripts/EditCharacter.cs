using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EditCharacter : MonoBehaviour {
    public GameObject charInScene;
    public GameObject grid;
    public GameObject slotPrefab;


    [Space] [Space] public ItemGroup[] bodyPrefabs;
    [Space] [Space] public ItemGroup[] hairPrefabs;
    string lastClickedItem = " ";
    List<Transform> slots;
    string lastSlot;
    [Space] [Space] public Image[] panelTypeImgs;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("FirstEdit"))
        {
            PlayerPrefs.SetInt("FirstEdit", 1);
            PlayerPrefs.Save();
            StartSavingPlayer(charInScene);
        }
        else
            LoadPlayer();

        //pc debug

        //PlayerPrefs.DeleteKey("FirstEdit"))
        //PlayerPrefs.Save();
        //File.Delete(Application.persistentDataPath + "/player.fun");


    }


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

            for (int i = 0; i < itemGroup.items.Length; i++)
            {
                if (i != 0)
                {
                    Transform t = Instantiate(slot.GetChild(0), slot.transform);
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
        GameObject[] objsWithTag = GameObject.FindGameObjectsWithTag(itemGroup.type.ToString() + "Equipped");
        foreach (GameObject obj in objsWithTag)
            Destroy(obj);

        //Cria itens novos
        for (int i = 0; i < itemGroup.items.Length; i++)
        {
            int charPartID = itemGroup.items[i].characterPos.GetHashCode();
            Transform slot = Instantiate(panelTypeImgs[charPartID].transform, charInScene.transform);
            slot.GetComponent<Image>().sprite = itemGroup.items[i].sprite;
            Vector3 pos = slot.GetComponent<RectTransform>().localPosition;
            pos.y = itemGroup.items[i].rectY;
            slot.GetComponent<RectTransform>().localPosition = pos;
            slot.SetSiblingIndex(itemGroup.items[i].layer); //muda a ordem na hierarquia
            slot.tag = itemGroup.type.ToString() + "Equipped";
            slot.gameObject.SetActive(true);
        }

    }



    public void SaveAndExit(GameObject charInScene)
    {
        StartSavingPlayer(charInScene);
        ScreenFlow.Instance.LoadPreviousScene();
    }

    void StartSavingPlayer(GameObject charInScene)
    {
        CharFullParts charFullParts = new CharFullParts();
        int i = 0;
        foreach (Transform child in charInScene.transform)
        {
            CharPart charPart = new CharPart(
                         child.GetComponent<ResourcePath>().resourcePath,
                         child.localPosition.x,
                         child.localPosition.y,
                         child.gameObject.activeSelf,
                         i,
                         child.tag
                     );
            charFullParts.allCharParts.Add(charPart);
            i++;
        }
        //SAVE
        SavePlayer(charFullParts);
    }

    void SavePlayer(CharFullParts fullParts)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream fs = new FileStream(path, FileMode.Create);
        formatter.Serialize(fs, fullParts);
        fs.Close();
    }

    void LoadPlayer()
    {
        //delete old
        foreach (Transform child in charInScene.transform)
        {
            Destroy(child.gameObject);
        }
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            CharFullParts fullParts = formatter.Deserialize(fs) as CharFullParts;

            //create new avatar
            foreach(CharPart charPart in fullParts.allCharParts)
            {
                GameObject part = Instantiate(Resources.Load(charPart.prefabPath) as GameObject,charInScene.transform);
                Vector3 pos = new Vector3(charPart.rectPos[0], charPart.rectPos[1], 0);
                part.GetComponent<RectTransform>().localPosition = pos;
                part.SetActive(charPart.isActive);
                part.tag = charPart.tag;
                part.transform.SetSiblingIndex(charPart.posAsChild);
            }
            fs.Close();
        }
    }
}



