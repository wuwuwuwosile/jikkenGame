using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeCountText : MonoBehaviour
{
    Text text_rangeCounter;

    void Start()
    {
        text_rangeCounter = GetComponent<Text>();
    }


    void Update()
    {
        text_rangeCounter.text = "Range:" + string.Format("{0:D3}", GameManager.k);
    }
}
