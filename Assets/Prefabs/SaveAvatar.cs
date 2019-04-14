using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SaveAvatar : MonoBehaviour {

    public GameObject characterPrefab;

    public void Save()
    {

        //altera e salva o prefab
        var instanceRoot = this.gameObject;
        var targetPrefab = characterPrefab;
        PrefabUtility.ReplacePrefab(
                instanceRoot,
                targetPrefab,
                ReplacePrefabOptions.ConnectToPrefab
                );
    }
}
