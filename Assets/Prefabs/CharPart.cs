using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CharPart {
    public string prefabPath;
    public float[] rectPos;
    public bool isActive;
    public int posAsChild;
    public string tag;

    public CharPart(string prefabPath, float rectPosX, float rectPosY, bool isActive, int posAsChild, string tag)
    {
        this.prefabPath = prefabPath;
        this.rectPos = new float[2];
        rectPos[0] = rectPosX;
        rectPos[1] = rectPosY;
        this.isActive = isActive;
        this.posAsChild = posAsChild;
        this.tag = tag;
    }
}
