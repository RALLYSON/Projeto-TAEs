using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousScene : MonoBehaviour {

    public void OnClick()
    {
        ScreenFlow.Instance.LoadPreviousScene();

    }
    //public void OnClickDelayed(float time)
    //{
    //    StartCoroutine(OnClickDelay(time));

    //}
    //IEnumerator OnClickDelay(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    ScreenFlow.Instance.LoadPreviousScene();

    //}
}
