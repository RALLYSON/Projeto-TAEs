using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SaveAvatar : MonoBehaviour {

    public GameObject characterPrefab;
    public GameObject characterInScene;

    

    public void SaveAndExit(GameObject characterPrefab, GameObject characterInScene)
    {

        //altera e salva o prefab
        var instanceRoot = characterPrefab;
        var targetPrefab = characterPrefab;
        PrefabUtility.ReplacePrefab(
                instanceRoot.gameObject,
                targetPrefab,
                ReplacePrefabOptions.ConnectToPrefab
                );
        ScreenFlow.Instance.LoadPreviousScene();
    }
}
