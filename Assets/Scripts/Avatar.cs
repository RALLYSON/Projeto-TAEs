using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class Avatar : MonoBehaviour {

    public GameObject charInScene;

    private void Awake()
    {
        //Instantiate(charInScene);
        LoadPlayer();
    }

    void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            CharFullParts fullParts = formatter.Deserialize(fs) as CharFullParts;
            //create new avatar

            foreach (CharPart charPart in fullParts.allCharParts)
            {
                GameObject part = Instantiate(Resources.Load(charPart.prefabPath) as GameObject, charInScene.transform);
                //part.transform.SetParent(charInScene.transform);
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
