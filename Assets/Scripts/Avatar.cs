using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Avatar : MonoBehaviour {

    public GameObject characterPrefab;
  
    private void Awake()
    {
        Instantiate(characterPrefab, this.transform);
    }

}
