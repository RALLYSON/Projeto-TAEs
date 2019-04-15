using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharPart {
    public string prefabPath;
    public Vector3 rectPos;
    public bool isActive;
    public int posAsChild;
    public string tag;

    public CharPart(string prefabPath, Vector3 rectPos, bool isActive, int posAsChild, string tag)
    {
        this.prefabPath = prefabPath;
        this.rectPos = rectPos;
        this.isActive = isActive;
        this.posAsChild = posAsChild;
        this.tag = tag;
    }
}
