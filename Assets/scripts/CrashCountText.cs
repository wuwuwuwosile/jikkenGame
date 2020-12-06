using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrashCountText : MonoBehaviour
{
    Text text_crashCounter;

    void Start()
    {
        text_crashCounter = GetComponent<Text>();
    }


    void Update()
    {
        text_crashCounter.text = "Crash:" + string.Format("{0:D3}", GameManager.j);
    }
}
