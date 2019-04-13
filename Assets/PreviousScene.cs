using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousScene : MonoBehaviour {

	public void OnClick()
    {
        ScreenFlow.Instance.LoadPreviousScene();
    }
}
