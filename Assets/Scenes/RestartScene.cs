﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScene : MonoBehaviour {

    public void OnClick()
    {
        ScreenFlow.Instance.RestartScene();
    }
}
