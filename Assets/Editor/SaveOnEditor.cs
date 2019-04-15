using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public  class SaveOnEditor :MonoBehaviour {

    public static class SaveAvatar
    {
        public static void Save(GameObject characterPrefab, GameObject characterInScene)
        {

            //altera e salva o prefab
            var instanceRoot = characterInScene;
            var targetPrefab = characterInScene;
            PrefabUtility.ReplacePrefab(
                    instanceRoot,
                    targetPrefab,
                    ReplacePrefabOptions.ConnectToPrefab
                    );
        }

        public static void SaveAndExit(GameObject characterPrefab, GameObject characterInScene)
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

   
}
